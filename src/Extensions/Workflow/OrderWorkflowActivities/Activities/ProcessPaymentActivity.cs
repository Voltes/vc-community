﻿using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Client;
using VirtoCommerce.Foundation.Frameworks.Extensions;
using VirtoCommerce.Foundation.Orders.Exceptions;
using VirtoCommerce.Foundation.Orders.Model;
using VirtoCommerce.Foundation.Orders.Model.PaymentMethod;
using VirtoCommerce.Foundation.Orders.Repositories;
using VirtoCommerce.Foundation.Orders.Services;
using VirtoCommerce.Foundation.Stores.Model;
using VirtoCommerce.Foundation.Stores.Repositories;

namespace VirtoCommerce.OrderWorkflow
{
    using System.Diagnostics;

    public class ProcessPaymentActivity : OrderActivityBase
	{
		public ProcessPaymentActivity()
		{
		}

		public ProcessPaymentActivity(IPaymentMethodRepository paymentMethodRepository, IStoreRepository storeRepository)
			: this()
		{
			_paymentMethodRepository = paymentMethodRepository;
			_storeRepository = storeRepository;
		}

		private IPaymentMethodRepository _paymentMethodRepository;
		private IPaymentMethodRepository PaymentMethodRepository
		{
			get
			{
				return _paymentMethodRepository?? (_paymentMethodRepository= ServiceLocator.GetInstance<IPaymentMethodRepository>());
			}
		}

		private IStoreRepository _storeRepository;
		private IStoreRepository StoreRepository
		{
			get
			{
				return _storeRepository?? ( _storeRepository = ServiceLocator.GetInstance<IStoreRepository>());
			}
		}

		protected override void Execute(System.Activities.CodeActivityContext context)
		{
			base.Execute(context);
			ProcessPayment();
		}


		/// <summary>
		/// Validates the order properties.
		/// </summary>
		private bool ValidateOrderProperties()
		{
			// Cycle through all Order Forms and check total, it should be equal to total of all payments
			var paymentTotal = CurrentOrderGroup.OrderForms.SelectMany(orderForm => orderForm.Payments).Sum(payment => payment.Amount);

			if (paymentTotal < CurrentOrderGroup.Total)
			{
                Trace.TraceError(String.Format("Payment Total Price less that order total price."));
				RegisterWarning(WorkflowMessageCodes.INVALID_PAYMENT_TOTAL,
					"The payment and the order total does not not match. Please adjust your payment");
				return false;
			}

			return true;
		}
		

		/// <summary>
		/// Processes the payment.
		/// </summary>
		private void ProcessPayment()
		{
			var orderGroup = CurrentOrderGroup;
			// If total is 0, we do not need to proceed
			if (orderGroup.Total == 0)
				return;

			//If validation 
			if (!ValidateOrderProperties())
			{
				throw new PaymentException(PaymentException.ErrorType.PaymentTotalError, "", "Order payment validation failed. See warnings for more information");
			}

			// Start Charging!
			var methods = PaymentMethodRepository.PaymentMethods
				.Expand("PaymentGateway")
				.Expand("PaymentMethodPropertyValues")
				.ExpandAll().ToArray();
			foreach (var orderForm in orderGroup.OrderForms)
			{
				foreach (var payment in orderForm.Payments)
				{
					//Do not process payments with status Processing and Fail
					if (!payment.Status.Equals(PaymentStatus.Pending.ToString(), StringComparison.OrdinalIgnoreCase))
						continue;

					var paymentMethod = (from m in methods where m.PaymentMethodId.Equals(payment.PaymentMethodId) select m).FirstOrDefault();

					// If we couldn't find payment method specified, generate an error
					if (paymentMethod == null)
					{
						throw new MissingMethodException(String.Format("Specified payment method \"{0}\" has not been defined.", payment.PaymentMethodId));
					}

					Debug.WriteLine(String.Format("Getting the type \"{0}\".", paymentMethod.PaymentGateway.ClassType));
					var type = Type.GetType(paymentMethod.PaymentGateway.ClassType);
				    if (type == null)
				    {
				        throw new TypeLoadException(
				            String.Format(
				                "Specified payment method class \"{0}\" can not be created.", paymentMethod.PaymentGateway.ClassType));
				    }

                    Debug.WriteLine(String.Format("Creating instance of \"{0}\".", type.Name));
					var provider = (IPaymentGateway)Activator.CreateInstance(type);

					provider.Settings = CreateSettings(paymentMethod);

					var message = "";
                    Debug.WriteLine(String.Format("Processing the payment."));
					if (provider.ProcessPayment(payment, ref message))
					{
						// should be changed by a payment gateway itself
						// payment.Status = PaymentStatus.Completed.ToString();
					}
					else
					{
						payment.Status = PaymentStatus.Failed.ToString();
						throw new PaymentException(PaymentException.ErrorType.ProviderError, "", message);
					}
					Debug.WriteLine(String.Format("Payment processed."));
					PostProcessPayment(payment);

					// TODO: add message to transaction log
				}
			}
		}

		/// <summary>
		/// Post process the payment. Decrypts the data if needed.
		/// </summary>
		private void PostProcessPayment(Payment payment)
		{
			// We only care about credit cards here, all other payment types should be encrypted by default
			var cardPayment = payment as CreditCardPayment;
			var store = StoreRepository.Stores.FirstOrDefault(s => s.StoreId == payment.OrderForm.OrderGroup.StoreId);
			if (cardPayment != null)
			{
				if (store != null)
				{
					switch ((CreditCardSavePolicy)store.CreditCardSavePolicy)
					{
						case CreditCardSavePolicy.Full:
							//leave full number
							break;
						case CreditCardSavePolicy.LastFourDigits:
							var ccNumber = cardPayment.CreditCardNumber;
							if (!String.IsNullOrEmpty(ccNumber) && ccNumber.Length > 4)
							{
								ccNumber = ccNumber.Substring(ccNumber.Length - 4);
								cardPayment.CreditCardNumber = ccNumber;
							}
							break;
						case CreditCardSavePolicy.None:
							cardPayment.CreditCardNumber = string.Empty;
							break;
					}
				}
				else
				{
					cardPayment.CreditCardNumber = string.Empty;
				}

				// Always remove pin
				cardPayment.CreditCardSecurityCode = String.Empty;
			}
		}

		private Dictionary<string, string> CreateSettings(PaymentMethod method)
		{
			var settings = method.PaymentMethodPropertyValues.ToDictionary(property => property.Name, property => property.ToString());
			settings["Gateway"] = method.PaymentGateway.GatewayId;
			return settings;
		}
	}
}

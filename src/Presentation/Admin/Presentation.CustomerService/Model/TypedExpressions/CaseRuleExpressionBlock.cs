﻿using System;
using VirtoCommerce.ManagementClient.Core.Controls;
using VirtoCommerce.ManagementClient.Core.Infrastructure;
using VirtoCommerce.Foundation.Customers.Model;
using VirtoCommerce.Foundation.Frameworks;
using VirtoCommerce.ManagementClient.Customers.ViewModel.Settings.CaseRules.Interfaces;

namespace VirtoCommerce.ManagementClient.Customers.Model
{
    [Serializable]
    public class CaseRuleExpressionBlock : TypedExpressionElementBase, IExpressionCaseAlertsAdaptor
    {
        private ConditionAndOrBlock _ConditionBlock;
        public ConditionAndOrBlock ConditionBlock
        {
            get
            {
                return _ConditionBlock;
            }
            private set
            {
                _ConditionBlock = value;
                Children.Add(_ConditionBlock);
            }
        }

        private ActionBlock _ActionBlock;
        public ActionBlock ActionBlock
        {
            get
            {
                return _ActionBlock;
            }
            private set
            {
                _ActionBlock = value;
                Children.Add(_ActionBlock);
            }
        }

        public CaseRuleExpressionBlock(ICaseRuleViewModel caseRuleViewModel)
            : base(null, caseRuleViewModel)
        {
            ConditionBlock = new ConditionAndOrBlock("If", caseRuleViewModel, "of these conditions are true");
            ActionBlock = new ActionBlock("apply these alerts", caseRuleViewModel);

            InitializeAvailableExpressions();
        }

        private void InitializeAvailableExpressions()
        {
            var availableElements = new Func<CompositeElement>[] {
				//()=> {
				//	var group = new CompositeElement { DisplayName = "Customer conditions" };
				//	group.AvailableChildrenGetters.AddRange(new Func<ExpressionElement>[] {
				//		()=> new ConditionCustomerStatus(this.ExpressionViewModel)
				//	});
				//	return group;
				//},

				()=> {
					var group = new CompositeElement { DisplayName = "Case conditions" };
					group.AvailableChildrenGetters.AddRange(new Func<ExpressionElement>[] {
						()=> new ConditionCaseStatus(this.ExpressionViewModel)
					});
					return group;
				}

				//()=> {
				//	var group = new CompositeElement { DisplayName = "Order conditions" };
				//	group.AvailableChildrenGetters.AddRange(new Func<ExpressionElement>[] {
				//		()=> new ConditionOrderStatus(this.ExpressionViewModel)
				//	});
				//	return group;
				//}
            };

            ConditionBlock.WithAvailabeChildren(availableElements);
            ConditionBlock.NewChildLabel = "+ add condition";

            availableElements = new Func<CompositeElement>[] {
                ()=> new ActionXslInlineAlert(this.ExpressionViewModel),
				()=> new ActionHtmlInlineAlert(this.ExpressionViewModel),
                ()=> new ActionRedirectAlert(this.ExpressionViewModel)	
            };

            ActionBlock.WithAvailabeChildren(availableElements);
            ActionBlock.NewChildLabel = "+ add effect";
        }

        public override void InitializeAfterDeserialized(IExpressionViewModel CaseRuleViewModel)
        {
            base.InitializeAfterDeserialized(CaseRuleViewModel);
            InitializeAvailableExpressions();

        }

        public System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetExpression()
        {
            var retVal = ConditionBlock.GetExpression();
            return retVal;
        }

		public virtual CaseAlert[] GetCaseAlerts()
		{
			return ActionBlock.GetCaseAlerts();
		}
    }
}

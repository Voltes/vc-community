﻿using System.Collections.Generic;

namespace VirtoCommerce.Foundation.Security.Model
{
    public static class PredefinedPermissions
    {
        //public const string CatalogAttributesCreate = "catalog:attributes:create",
        //                CatalogAttributesEdit = "catalog:attributes:edit",
        //                CatalogAttributesDelete = "catalog:attributes:delete",
        public const string

            CustomersViewAllCasesAll = "customers:case:view:all",
            CustomersViewAssignedCases = "customers:case:view:assigned",
            CustomersSearchCases = "customers:case:search",
            CustomersCreateNewCase = "customers:case:create",
            CustomersEditCaseProperties = "customers:case:edit",
            CustomersDeleteExistingCase = "customers:case:delete",
            CustomersAddCaseComments = "customers:case:comments:public_and_private",
            CustomersAddCustomerComments = "customers:customer:comments:private",
            CustomersCreateCustomer = "customers:customer:create",
            CustomersEditCustomer = "customers:customer:edit",
            CustomersDeleteCustomer = "customers:customer:delete",
            CustomersLoginAsCustomer = "customers:customer:login",
            CustomersCreateResetPasswords = "customers:contact:account:password",
            CustomersSuspendAccounts = "customers:contact:lock:manage",
            CustomersCreateContactAccount = "customers:contact:account:create",

            OrdersAll = "orders:orders:all",
            OrdersCreateOrderReturns = "orders:orders_refunds:create",
            OrdersCompleteOrderReturns = "orders:orders_refunds:complete",
            OrdersCancelOrderReturns = "orders:orders_refunds:cancel",
            OrdersIssueOrderReturns = "orders:orders_refunds:issue",
            OrdersCreateOrderExchange = "orders:orders_exchange:create",

            CatalogItemsManage = "catalog:items:manage",
            CatalogCatalogsManage = "catalog:catalogs:manage",
            CatalogCategoriesManage = "catalog:categories:manage",
            CatalogVirtual_CatalogsManage = "catalog:virtual_catalogs:manage",
            CatalogLinked_CategoriesManage = "catalog:linked_categories:manage",
            CatalogCatalog_Import_JobsRun = "catalog:catalog_import_jobs:manage",
            CatalogCatalog_Import_JobsManage = "catalog:catalog_import_jobs:run",
            CatalogItemAssociationsManage = "catalog:item:associations:manage",
            CatalogEditorialReviewsCreateEdit = "catalog:item:editorial_reviews:create_edit",
            CatalogEditorialReviewsPublish = "catalog:item:editorial_reviews:publish",
            CatalogEditorialReviewsRemove = "catalog:item:editorial_reviews:remove",
            CatalogCustomerReviewsManage = "catalog:customer_reviews:manage",

            PricingPrice_ListsManage = "pricing:price_lists:manage",
            PricingPrice_ItemPricingManage = "pricing:item:manage",
            PricingPrice_ListsImport_Jobs = "pricing:price_lists:import_jobs",
            PricingPrice_ListsImport_JobsRun = "pricing:price_lists:import_jobs:run",
            PricingPrice_List_AssignmentsManage = "pricing:price_list_assignments:manage",

            MarketingPromotionsManage = "marketing:promotions:manage",
            MarketingDynamic_ContentManage = "marketing:dynamic_content:manage",
            MarketingContent_PublishingManage = "marketing:content_publishing:manage",

            FulfillmentInventoryManage = "fulfillment:inventory:manage",
            FulfillmentPicklistsManage = "fulfillment:picklists:manage",
            FulfillmentInventoryReceive = "fulfillment:inventory:receive",
            FulfillmentCompleteShipment = "fulfillment:complete_shipment",
            FulfillmentReturnsManage = "fulfillment:returns:manage",

            ReportingViewReports = "reporting:view",
            ReportingManageReports = "reporting:manage",

            SecurityAccounts = "security:accounts:manage",
            SecurityRoles = "security:roles:manage",

            SettingsAppConfigSettings = "appconfig:settings:config",
            SettingsAppConfigSystemJobs = "appconfig:system_jobs:config",
            SettingsAppConfigEmailTemplates = "appconfig:email_templates:config",
            SettingsAppConfigDisplayTemplates = "appconfig:display_templates:config",
            SettingsCustomerInfo = "customers:info:config",
            SettingsCustomerCaseTypes = "customers:case_types:config",
            SettingsCustomerRules = "customers:rules:config",
            SettingsFulfillment = "fulfillment:config",
            SettingsStores = "stores:config",
            SettingsJurisdiction = "jurisdictions:config",
            SettingsJurisdictionGroups = "jurisdiction_groups:config",
            SettingsTaxCategories = "tax_categories:config",
            SettingsTaxes = "taxes:config",
            SettingsTaxImport = "tax_import:config",
            SettingsShippingMethods = "shipping:methods:config",
            SettingsShippingPackages = "shipping:packages:config",
            SettingsShippingOptions = "shipping:options:config",
            SettingsContent_Places = "content_place:config",
            SettingsPayment_Methods = "payments:config",

            ShopperRestrictedAccess = "stores:restricted:access",
            ShopperClosedAccess = "stores:closed:access",

            SettingsSearch = "search:config";

        public const string
            Name_CustomersViewAllCasesAll = "View all cases",
            Name_CustomersViewAssignedCases = "View cases only assigned to a user",
            Name_CustomersSearchCases = "Search cases",
            Name_CustomersCreateNewCase = "Create new case",
            Name_CustomersEditCaseProperties = "Edit case properties",
            Name_CustomersDeleteExistingCase = "Delete existing case",
            Name_CustomersAddCaseComments = "Add public and private case comments",
            Name_CustomersAddCustomerComments = "Add private comments to a customer",
            Name_CustomersCreateCustomer = "Create customer",
            Name_CustomersEditCustomer = "Edit customer properties",
            Name_CustomersDeleteCustomer = "Delete existing customer",
            Name_CustomersCreateResetPasswords = "Create and reset passwords",
            Name_CustomersSuspendAccounts = "Suspend and suspend accounts",
            Name_CustomersCreateContactAccount = "Create account for a contact",
            Name_CustomersLoginAsCustomer = "Login on behalf of a contact",

            Name_OrdersAll = "Manage Orders",
            Name_OrdersCreateOrderReturns = "Create Order Returns",
            Name_OrdersCompleteOrderReturns = "Complete Order Returns",
            Name_OrdersCancelOrderReturns = "Cancel Order Returns",
            Name_OrdersIssueOrderReturns = "Issue Order Refunds",
            Name_OrdersCreateOrderExchange = "Create Order Exchange",

            Name_OrdersOrdersAll = "Manage Orders",
            Name_OrdersOrder_PaymentsAll = "Manage Order Payments",
            Name_OrdersOrder_ExchangesAll = "Manage Order Exchanges",

            Name_CatalogItemsManage = "Manage Catalog Items",
            Name_CatalogCatalogsManage = "Manage Catalogs",
            Name_CatalogCategoriesManage = "Manage Categories",
            Name_CatalogVirtual_CatalogsManage = "Manage Virtual Catalogs",
            Name_CatalogLinked_CategoriesManage = "Manage Linked Categories",
            Name_CatalogCatalog_Import_JobsRun = "Run Catalog Import Jobs",
            Name_CatalogCatalog_Import_JobsManage = "Manage Catalog Import Jobs",
            Name_CatalogItemAssociationsManage = "Manage Item Associations",
            Name_CatalogEditorialReviewsCreateEdit = "Create/Edit Editorial Reviews",
            Name_CatalogEditorialReviewsPublish = "Publish Editorial Reviews",
            Name_CatalogEditorialReviewsRemove = "Remove Editorial Reviews",
            Name_CatalogCustomerReviewsManage = "Manager Customer Reviews",

            Name_PricingPrice_ListsManage = "Manage Price Lists",
            Name_PricingPrice_ItemPricingManage = "Manage Item Pricing",
            Name_PricingPrice_ListsImport_Jobs = "PriceList Import Jobs",
            Name_PricingPrice_ListsImport_JobsRun = "Run PriceList Import Job",
            Name_PricingPrice_List_AssignmentsManage = "Manage PriceList Assignments",

            Name_MarketingPromotionsManage = "Manage Promotions",
            Name_MarketingDynamic_ContentManage = "Manage Dynamic Content",
            Name_MarketingContent_PublishingManage = "Manage Content Publishing",


            Name_FulfillmentInventoryManage = "Manage Fulfillment Inventory",
            Name_FulfillmentPicklistsManage = "Manage Fulfillment Picklists",
            Name_FulfillmentInventoryReceive = "Receive Fulfillment Inventory",
            Name_FulfillmentCompleteShipment = "Complete Shipment",
            Name_FulfillmentReturnsManage = "Edit Returns and Exchanges",

            Name_ReportingViewReports = "View reports",
            Name_ReportingManageReports = "Manage reports",

            Name_SecurityAccounts = "Manage Accounts",
            Name_SecurityRoles = "Manage Roles",

            Name_SettingsCustomer_SettingsAll = "Config Customer Settings",
            Name_SettingsContent_PlacesAll = "Config Content Places",
            Name_SettingsFulfillment_CentersAll = "Config Fulfillment Centers",
            Name_SettingsStores = "Config Stores",
            Name_SettingsPayment_MethodsAll = "Config Payment Methods",
            Name_SettingsShippingAll = "Config Shipping",
            Name_SettingsTaxesAll = "Config Taxes",
            Name_SettingsSearchAll = "Config Search",
            Name_SettingsAppConfigSettings = "Config AppConfig Settings",
            Name_SettingsAppConfigSystemJobs = "Config AppConfig System Jobs",
            Name_SettingsAppConfigEmailTemplates = "Config AppConfig Email templates",
            Name_SettingsAppConfigDisplayTemplates = "Config AppConfig Display templates",
            Name_SettingsCustomerInfo = "Config Customers info",
            Name_SettingsCustomerCaseTypes = "Config Customers case types",
            Name_SettingsShippingMethods = "Config Shipping methods",
            Name_SettingsShippingPackages = "Config Shipping packages",
            Name_SettingsJurisdiction = "Config Jurisdictions",
            Name_SettingsJurisdictionGroups = "Config Jurisdiction Groups",
            Name_SettingsTaxCategories = "Config Tax Categories",
            Name_SettingsTaxImport = "Config Tax import",
            Name_ShopperRestrictedAccess = "Access Restricted Stores",
            Name_ShopperClosedAccess = "Access Closed Stores";


        public const string
            Role_SuperAdmin = "Super Admin",
            Role_CustomerService = "Customer service agent",
            Role_CatalogManagement = "Catalog manager",
            Role_Marketing = "Store marketing",
            Role_Fulfillment = "Shipping receiving",
            Role_ConfigurationManagement = "Configuration",
            Role_PrivateShopper = "Private Shopper";

        public static List<Permission> GetAllPermissions()
        {
            return new List<Permission>
				{
					new Permission {PermissionId = CustomersViewAllCasesAll, Name = Name_CustomersViewAllCasesAll},
					new Permission {PermissionId = CustomersViewAssignedCases, Name = Name_CustomersViewAssignedCases},
					new Permission {PermissionId = CustomersSearchCases, Name = Name_CustomersSearchCases},
					new Permission {PermissionId = CustomersCreateNewCase, Name = Name_CustomersCreateNewCase},
					new Permission {PermissionId = CustomersEditCaseProperties, Name = Name_CustomersEditCaseProperties},
					new Permission {PermissionId = CustomersDeleteExistingCase, Name = Name_CustomersDeleteExistingCase},
					new Permission {PermissionId = CustomersAddCaseComments, Name = Name_CustomersAddCaseComments},
					new Permission {PermissionId = CustomersAddCustomerComments, Name = Name_CustomersAddCustomerComments},
					new Permission {PermissionId = CustomersCreateCustomer, Name = Name_CustomersCreateCustomer},
					new Permission {PermissionId = CustomersEditCustomer, Name = Name_CustomersEditCustomer},
					new Permission {PermissionId = CustomersDeleteCustomer, Name = Name_CustomersDeleteCustomer},
					new Permission {PermissionId = CustomersCreateResetPasswords, Name = Name_CustomersCreateResetPasswords},
					new Permission {PermissionId = CustomersSuspendAccounts, Name = Name_CustomersSuspendAccounts},
					new Permission {PermissionId = CustomersCreateContactAccount, Name = Name_CustomersCreateContactAccount},
                    new Permission {PermissionId = CustomersLoginAsCustomer, Name = Name_CustomersLoginAsCustomer},

					new Permission {PermissionId = OrdersAll, Name = Name_OrdersAll},
					new Permission {PermissionId = OrdersCreateOrderReturns, Name = Name_OrdersCreateOrderReturns},
					new Permission {PermissionId = OrdersCompleteOrderReturns, Name = Name_OrdersCompleteOrderReturns},
					new Permission {PermissionId = OrdersCancelOrderReturns, Name = Name_OrdersCancelOrderReturns},
					new Permission {PermissionId = OrdersIssueOrderReturns, Name = Name_OrdersIssueOrderReturns},
					new Permission {PermissionId = OrdersCreateOrderExchange, Name = Name_OrdersCreateOrderExchange},

					new Permission {PermissionId = CatalogItemsManage, Name = Name_CatalogItemsManage},
					new Permission {PermissionId = CatalogCatalogsManage, Name = Name_CatalogCatalogsManage},
					new Permission {PermissionId = CatalogCategoriesManage, Name = Name_CatalogCategoriesManage},
					new Permission {PermissionId = CatalogVirtual_CatalogsManage, Name = Name_CatalogVirtual_CatalogsManage},
					new Permission {PermissionId = CatalogLinked_CategoriesManage, Name = Name_CatalogLinked_CategoriesManage},
					new Permission {PermissionId = CatalogCatalog_Import_JobsRun, Name = Name_CatalogCatalog_Import_JobsRun},
					new Permission {PermissionId = CatalogCatalog_Import_JobsManage, Name = Name_CatalogCatalog_Import_JobsManage},
					new Permission {PermissionId = CatalogItemAssociationsManage, Name = Name_CatalogItemAssociationsManage},
					new Permission {PermissionId = CatalogEditorialReviewsCreateEdit, Name = Name_CatalogEditorialReviewsCreateEdit},
					new Permission {PermissionId = CatalogEditorialReviewsPublish, Name = Name_CatalogEditorialReviewsPublish},
					new Permission {PermissionId = CatalogEditorialReviewsRemove, Name = Name_CatalogEditorialReviewsRemove},
					new Permission {PermissionId = CatalogCustomerReviewsManage, Name = Name_CatalogCustomerReviewsManage},

					new Permission {PermissionId = PricingPrice_ListsManage, Name = Name_PricingPrice_ListsManage},
					new Permission {PermissionId = PricingPrice_ItemPricingManage, Name = Name_PricingPrice_ItemPricingManage},
					new Permission {PermissionId = PricingPrice_ListsImport_Jobs, Name = Name_PricingPrice_ListsImport_Jobs},
					new Permission {PermissionId = PricingPrice_ListsImport_JobsRun, Name = Name_PricingPrice_ListsImport_JobsRun},
					new Permission
						{
							PermissionId = PricingPrice_List_AssignmentsManage,
							Name = Name_PricingPrice_List_AssignmentsManage
						},

					new Permission {PermissionId = MarketingPromotionsManage, Name = Name_MarketingPromotionsManage},
					new Permission {PermissionId = MarketingDynamic_ContentManage, Name = Name_MarketingDynamic_ContentManage},
					new Permission {PermissionId = MarketingContent_PublishingManage, Name = Name_MarketingContent_PublishingManage},

					new Permission {PermissionId = FulfillmentInventoryManage, Name = Name_FulfillmentInventoryManage},
					new Permission {PermissionId = FulfillmentInventoryReceive, Name = Name_FulfillmentInventoryReceive},
					new Permission {PermissionId = FulfillmentPicklistsManage, Name = Name_FulfillmentPicklistsManage},
					new Permission {PermissionId = FulfillmentCompleteShipment, Name = Name_FulfillmentCompleteShipment},
					new Permission {PermissionId = FulfillmentReturnsManage, Name = Name_FulfillmentReturnsManage},

                    new Permission {PermissionId = ReportingViewReports, Name = Name_ReportingViewReports},
                    new Permission {PermissionId = ReportingManageReports, Name = Name_ReportingManageReports},

					new Permission {PermissionId = SecurityAccounts, Name = Name_SecurityAccounts},
					new Permission {PermissionId = SecurityRoles, Name = Name_SecurityRoles},

					new Permission {PermissionId = SettingsCustomerRules, Name = Name_SettingsCustomer_SettingsAll},
					new Permission {PermissionId = SettingsContent_Places, Name = Name_SettingsContent_PlacesAll},
					new Permission {PermissionId = SettingsFulfillment, Name = Name_SettingsFulfillment_CentersAll},
					new Permission {PermissionId = SettingsStores, Name = Name_SettingsStores},
					new Permission {PermissionId = SettingsPayment_Methods, Name = Name_SettingsPayment_MethodsAll},
					new Permission {PermissionId = SettingsShippingOptions, Name = Name_SettingsShippingAll},
					new Permission {PermissionId = SettingsTaxes, Name = Name_SettingsTaxesAll},
					new Permission {PermissionId = SettingsSearch, Name = Name_SettingsSearchAll},
					new Permission {PermissionId = SettingsAppConfigSettings, Name = Name_SettingsAppConfigSettings},
					new Permission {PermissionId = SettingsAppConfigSystemJobs, Name = Name_SettingsAppConfigSystemJobs},
					new Permission {PermissionId = SettingsAppConfigEmailTemplates, Name = Name_SettingsAppConfigEmailTemplates},
					new Permission {PermissionId = SettingsAppConfigDisplayTemplates, Name = Name_SettingsAppConfigDisplayTemplates},
					new Permission {PermissionId = SettingsCustomerInfo, Name = Name_SettingsCustomerInfo},
					new Permission {PermissionId = SettingsCustomerCaseTypes, Name = Name_SettingsCustomerCaseTypes},
					new Permission {PermissionId = SettingsShippingMethods, Name = Name_SettingsShippingMethods},
					new Permission {PermissionId = SettingsShippingPackages, Name = Name_SettingsShippingPackages},
					new Permission {PermissionId = SettingsJurisdiction, Name = Name_SettingsJurisdiction},
					new Permission {PermissionId = SettingsJurisdictionGroups, Name = Name_SettingsJurisdictionGroups},
					new Permission {PermissionId = SettingsTaxCategories, Name = Name_SettingsTaxCategories},
					new Permission {PermissionId = SettingsTaxImport, Name = Name_SettingsTaxImport},

					new Permission {PermissionId = ShopperClosedAccess, Name = Name_ShopperClosedAccess},
					new Permission {PermissionId = ShopperRestrictedAccess, Name = Name_ShopperRestrictedAccess},

				};
        }

        public static List<string> ListCustomerServicePermissions()
        {
            return new List<string>
				{
					CustomersViewAllCasesAll,
					CustomersViewAssignedCases,
					CustomersSearchCases,
					CustomersCreateNewCase,
					CustomersEditCaseProperties,
					CustomersDeleteExistingCase,
					CustomersAddCaseComments,
					CustomersAddCustomerComments,
					CustomersCreateCustomer,
					CustomersEditCustomer,
					CustomersDeleteCustomer,
					CustomersCreateResetPasswords,
					CustomersSuspendAccounts,
					CustomersCreateContactAccount,
                    CustomersLoginAsCustomer
				};
        }

        public static List<string> ListCatalogPermissions()
        {
            return new List<string>
				{
					CatalogItemsManage,
					CatalogCatalogsManage,
					CatalogCategoriesManage,
					CatalogVirtual_CatalogsManage,
					CatalogLinked_CategoriesManage,
					CatalogCatalog_Import_JobsRun,
					CatalogCatalog_Import_JobsManage,
					CatalogItemAssociationsManage,
					CatalogEditorialReviewsCreateEdit,
					CatalogEditorialReviewsPublish,
					CatalogEditorialReviewsRemove,
					CatalogCustomerReviewsManage
				};
        }

        public static List<string> ListOrdersPermissions()
        {
            return new List<string>
				{
					OrdersAll,
					OrdersCreateOrderReturns,
					OrdersCompleteOrderReturns,
					OrdersCancelOrderReturns,
					OrdersIssueOrderReturns,
					OrdersCreateOrderExchange
				};
        }

        public static List<string> ListPricingPermissions()
        {
            return new List<string>
				{
					PricingPrice_ListsManage,
					PricingPrice_ItemPricingManage,
					PricingPrice_ListsImport_Jobs,
					PricingPrice_ListsImport_JobsRun,
					PricingPrice_List_AssignmentsManage
				};
        }

        public static List<string> ListMarketingPermissions()
        {
            return new List<string>
				{
					MarketingPromotionsManage,
					MarketingDynamic_ContentManage,
					MarketingContent_PublishingManage
				};
        }

        public static List<string> ListFulfillmentPermissions()
        {
            return new List<string>
				{
					FulfillmentInventoryManage,
					FulfillmentInventoryReceive,
					FulfillmentPicklistsManage,
					FulfillmentCompleteShipment,
					FulfillmentReturnsManage
				};
        }

        public static List<string> ListReportingPermissions()
        {
            return new List<string>
            {
                ReportingViewReports,
                ReportingManageReports
            };
        }

        public static List<string> ListUsersPermissions()
        {
            return new List<string>
				{
					SecurityAccounts,
					SecurityRoles
				};
        }

        public static List<string> ListShopperPermissions()
        {
            return new List<string>
				{
					ShopperClosedAccess,
					ShopperRestrictedAccess
				};
        }

        public static List<string> ListSettingsPermissions()
        {
            return new List<string>
				{
					SettingsCustomerRules,
					SettingsContent_Places,
					SettingsFulfillment,
					SettingsStores,
					SettingsPayment_Methods,
					SettingsShippingOptions,
					SettingsTaxes,
					SettingsSearch,
					SettingsAppConfigSettings,
					SettingsAppConfigSystemJobs,
					SettingsAppConfigEmailTemplates,
					SettingsAppConfigDisplayTemplates,
					SettingsCustomerInfo,
					SettingsCustomerCaseTypes,
					SettingsShippingMethods,
					SettingsShippingPackages,
					SettingsJurisdiction,
					SettingsJurisdictionGroups,
					SettingsTaxCategories,
					SettingsTaxImport
				};
        }

    }
}




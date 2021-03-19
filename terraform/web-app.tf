resource "azurerm_app_service_plan" "app-service-plan" {
    name = "web-appsvcplan-${var.environment}"
    resource_group_name = azurerm_resource_group.resource-group.name
    location = azurerm_resource_group.resource-group.location
    sku {
      tier = "Shared"
      size = "D1"
    }
}

resource "azurerm_app_service" "app-service" {
  name = "web-${var.environment}"
  location = var.region
  resource_group_name = azurerm_resource_group.resource-group.name
  app_service_plan_id = azurerm_app_service_plan.app-service-plan.id

  site_config {
    dotnet_framework_version  = "v5.0"
    # This is required to be set to support the shared app service plan
    use_32_bit_worker_process = true
  }
}
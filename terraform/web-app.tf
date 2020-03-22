resource "azurerm_resource_group" "resource-group" {
    name = "MX-Web-${var.environment}"
    location = "${var.region}"
}

resource "azurerm_app_service_plan" "app-service-plan" {
    name = "MX-Web-AppPlan-${var.environment}"
    resource_group_name = "${azurerm_resource_group.resource-group.name}"
    location = "${azurerm_resource_group.resource-group.location}"

    sku {
        tier = "Basic"
        size = "B1"
    }
}

resource "azurerm_app_service" "app-service" {
  name = "MX-WebApp-${var.environment}"
  location = "${var.region}"
  resource_group_name = "${azurerm_resource_group.resource-group.name}"
  app_service_plan_id = "${azurerm_app_service_plan.app-service-plan.id}"
}
resource "azurerm_resource_group" "resource-group" {
    name = "mx-web-${var.environment}"
    location = var.region
}

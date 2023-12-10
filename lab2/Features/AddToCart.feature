Feature: Login to SauceDemo

  Scenario: Login with valid credentials
    Given I am on the SauceDemo login page
    When I enter the username "standard_user" and password "secret_sauce"
    Then I should be logged in and see the products page
    When I add a product to the cart
    Then The product should be in the cart
    Then I should close Firefox
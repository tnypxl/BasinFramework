Feature: Non-Inclusive Locators
	In order to build a locator
	As an Element
	I want to be found based on properties I don't have

@mytag
Scenario: Locate element that excludes a given class name
	Given I am on the home page
	When I navigate to the example named 'Large & Deep DOM'
	Then I can locate element '2.1' excluding class name 'tier-3'

Scenario: Locate element that excludes a given descendant element
	Given I am on the home page
	When I navigate to the example named 'Large & Deep DOM'
	Then I can locate element '2.1' excluding descendant element '1.1'
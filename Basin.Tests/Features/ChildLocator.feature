Feature: Child Locator

    Background: Navigate to "Large & Deep DOM"
        Given I am on the home page
        And I navigate to the example named 'Large & Deep DOM'

    Scenario: Locates child of element
		Then I can locate the first child of element

	Scenario: Locates specific child of element
		Then I can locate child '13.2' of element '13.1'
Feature: Add/Remove Elements

	I must know about cats. I MUST!

	Scenario: Add Element
		Given I am on the home page
		And I navigate to the example named 'Add/Remove Elements'
		When I add an element to the page
		Then I can see 1 Delete button has been added

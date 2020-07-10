Feature: Add/Remove Elements

	I must know about cats. I MUST!
	
	Background:
		Given: I am on the home page

	Scenario: Add Element
		When I navigate to the example named 'Add/Remove Elements'
		And I add an element to the page
		Then I can see 1 Delete button has been added

	Scenario: Find element position before a given sibling
		When I navigate to the example named 'Large & Deep DOM'
		Then I can see that item '1.2' comes after item '1.1'

Feature: Basin Functional Tests

	I must know about cats. I MUST!
	
	Background:
		Given I am on the home page

	Scenario: Locates an element added to the page
		When I navigate to the example named 'Add/Remove Elements'
		And I add an element to the page
		Then I can see 1 Delete button has been added

	Scenario: Locates an element by its following element
		When I navigate to the example named 'Large & Deep DOM'
		Then I can locate element '1.2' by its following element '1.3'

	Scenario: Locates an element by its preceding element
		When I navigate to the example named 'Large & Deep DOM'
		Then I can locate element '1.3' by its preceding element '1.2'

	Scenario: Locates parent of element
		When I navigate to the example named 'Large & Deep DOM'
		Then I can locate parent '13.1' of element '14.1'

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
		Then I can locate element '1.3' that follows element '1.2'

	Scenario: Locates an element by its preceding element
		When I navigate to the example named 'Large & Deep DOM'
		Then I can locate element '1.2' that precedes element '1.3'

	Scenario: Locates parent of element
		When I navigate to the example named 'Large & Deep DOM'
		Then I can locate the first parent of element '4.1'

	Scenario: Locates specific parent of element
		When I navigate to the example named 'Large & Deep DOM'
		Then I can locate parent '1.1' of element '2.1'

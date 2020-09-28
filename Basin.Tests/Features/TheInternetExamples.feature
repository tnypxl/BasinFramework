Feature: Basin Functional Tests
	MUST LOCATE THE THINGS!!!

Background:
	Given I am on the home page

Scenario: Locates an element added to the page
	When I navigate to the example named 'Add/Remove Elements'
	And I add an element to the page
	Then I can see 1 Delete button has been added

Scenario: Locates element at a given position among multiple elements
	When I navigate to the example named 'Large & Deep DOM'
	Then I can locate a table cell in row 23 at column 6 whose text is '23.6'

Scenario: Locate element using traditional By method
	When I navigate to the example named 'Large & Deep DOM'
	Then I can locate element using By.Id 'sibling-2.1'
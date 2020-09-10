Feature: Locate elements by the value of their class attibrute
	In order to be located
	As an Element
	I want to be found based on my class attribute

Scenario: Locate element with a specific css class name
	Given I am on the home page
	And I navigate to the example named 'Large & Deep DOM'
	Then I can locate element '1.2' whose class attribute includes class name 'tier-1'

Scenario: Locate element with multiple class names
	Given I am on the home page
	And I navigate to the example named 'Large & Deep DOM'
	Then I can locate element '1.2' who class attribute includes multiple class names 'tier-1, item-2, large-12'

Scenario: Locate element with multiple class names with one exclusion
	Given I am on the home page
	And I navigate to the example named 'Large & Deep DOM'
	Then I can locate element '1.2' who class attribute includes multiple class names '!tier-2, item-2, large-12'
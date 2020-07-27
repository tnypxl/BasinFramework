Feature: Locate element by text

    Background:
        Given I am on the home page
        And I navigate to the example named 'Large & Deep DOM'

    Scenario: Element with exact text
        Then I can locate an element with exact text '3.1'
        

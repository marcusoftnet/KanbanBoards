
@AcceptanceTest
Feature: Navigate to the homepage on www.kanban-boards.com
   In order to see the most important information of the site
   As a user
   I want to navigate to the home page of the application

Scenario: Navigate to the homepage
   When I navigate to to the homepage
   Then I should see a list of the 3 most favorited Kanban boards
	   And I should see a list of the 3 latests added Kanban boards
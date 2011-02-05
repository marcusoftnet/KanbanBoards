Feature: Navigating to MyBoard
	In order to see all my boards and their status
	As a logged-in user
	I want to see a list of my boards

Background:
	Given the following Kanbanboards
		   | Title        | User       | TimesFavorited | Posted      | Thumbnail                        |
		   | Demo 1       | Marcus     | 100            | 2010-01-01  | /thumbnails/demo1_thumb.jpg      |
		   | Kanban 1     | David      | 1000           | 2010-04-01  | /thumbnails/kanban1_thumb.jpg    |
		   | Demo 2       | Joakim     | 300            | 2010-06-01  | /thumbnails/demo2_thumb.jpg      |
		   | My new board | Christophe | 50             | 2011-01-01  | /thumbnails/mynewboard_thumb.jpg |
		   | Demo 2       | Marcus     | 120            | 2009-01-01  | /thumbnails/demo2_thumb.jpg      |
		And I am logged in on the site as Marcus

Scenario: List my boards
	When I navigate to the MyBoards page
	Then I should be on the MyBoards page
		And the following boards should be listed as my boards:
			| Title        | User       | 
			| Demo 1       | Marcus     | 
			| Demo 2       | Marcus     | 
Feature: Creating a new Kanban board
	In order to show off my great kanban board and get some insightful feedback
	As a logged-in user
	I want to be able to create information about a new Kanban board

Background:
		Given the following Kanbanboards
		   | Title        | User       | TimesFavorited | Posted      | Thumbnail                        |
		   | Demo 1       | Marcus     | 100            | 2010-01-01  | /thumbnails/demo1_thumb.jpg      |
		   | Kanban 1     | David      | 1000           | 2010-04-01  | /thumbnails/kanban1_thumb.jpg    |
		   | Demo 2       | Joakim     | 300            | 2010-06-01  | /thumbnails/demo2_thumb.jpg      |
		   | My new board | Christophe | 50             | 2011-01-01  | /thumbnails/mynewboard_thumb.jpg |
		And I am logged in on the site as Marcus
		
Scenario: Create a Kanban board with all the required information
	When I navigate to to the create new kanbanboard page
	Then I should be on the Create page
	When I submit a board with the following information
			| Field			| Value															|
			| Title			| KanbanBoard 1													|
			| Description   | This is a board that we've put together in my last project	|
			| Tags			| Software, Developement, Swedish								|
			| BoardImage	| mycoolboard.jpg												|
	Then I should be redirected the MyBoards page
	When I am redirected to the MyBoards page
	Then I should be on the MyBoards page
		And the following boards should be listed as my boards:
			| Title			| User       | 
			| Demo 1		| Marcus     | 
			| KanbanBoard 1 | Marcus     |
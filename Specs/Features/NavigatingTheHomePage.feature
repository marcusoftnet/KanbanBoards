Feature: Navigate to the homepage on www.kanban-boards.com
   In order to see the most important information of the site
   As a user
   I want to navigate to the home page of the application

Background:
   Given the following Kanbanboards
   | Title        | User       | TimesFavorited | Posted      | Thumbnail                        |
   | Demo 1       | Marcus     | 100            | 2010-01-01  | /thumbnails/demo1_thumb.jpg      |
   | Kanban 1     | David      | 1000           | 2010-04-01  | /thumbnails/kanban1_thumb.jpg    |
   | Demo 2       | Joakim     | 300            | 2010-06-01  | /thumbnails/demo2_thumb.jpg      |
   | My new board | Christophe | 50             | 2011-01-01  | /thumbnails/mynewboard_thumb.jpg |

Scenario: See the 3 most favorited kanbanboards
   When I to to the homepage
   Then I should be on the Index page
   And I should see the following Kanbanboards as the most favorited:
   | Title    | User   | TimesFavorited | Posted     | Thumbnail                     |
   | Kanban 1 | David  | 1000           | 2010-04-01 | /thumbnails/kanban1_thumb.jpg |
   | Demo 2   | Joakim | 300            | 2010-06-01 | /thumbnails/demo2_thumb.jpg   |
   | Demo 1   | Marcus | 100            | 2010-01-01 | /thumbnails/demo1_thumb.jpg   |

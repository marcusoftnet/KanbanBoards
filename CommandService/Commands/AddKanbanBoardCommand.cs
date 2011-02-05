namespace CommandService.Commands
{
    public class AddKanbanBoardCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string BoardImage { get; set; }
        public string User { get; set; }
    }
}
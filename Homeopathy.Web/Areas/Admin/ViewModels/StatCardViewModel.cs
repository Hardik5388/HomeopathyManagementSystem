namespace Homeopathy.Web.Areas.Admin.ViewModels
{
    public class StatCardViewModel
    {
        public string Title { get; set; } = string.Empty;

        public int Value { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public string Color { get; set; } = "primary";

        public string ActionText { get; set; } = "View Details";

        public string ActionUrl { get; set; } = "#";

        public string GrowthText { get; set; } = "No change this month";
    }
}
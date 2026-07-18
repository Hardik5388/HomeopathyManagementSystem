namespace Homeopathy.Web.Areas.Admin.ViewModels.Common
{
    public class PageHeaderViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string? Subtitle { get; set; }

        public string? ButtonText { get; set; }

        public string? ButtonUrl { get; set; }

        public string? ButtonIcon { get; set; }

        public bool ShowButton => !string.IsNullOrWhiteSpace(ButtonText)
                               && !string.IsNullOrWhiteSpace(ButtonUrl);
    }
}

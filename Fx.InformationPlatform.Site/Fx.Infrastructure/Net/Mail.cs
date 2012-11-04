namespace Fx.Infrastructure.Net
{
    public class Mail
    {
        public string Address { get; set; }
        public string DisplayName { get; set; }
        public string Subject { get; set; }
        public string BodyHTML { get; set; }
        public string BodyPlain { get; set; }
    }
}
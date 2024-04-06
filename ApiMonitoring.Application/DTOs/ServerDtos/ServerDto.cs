namespace ApiMonitoring.Application.DTOs.ServerDtos
{
    public record ServerDto
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string OperatingSystem { get; set; }
        public bool IsOnline { get; set; }
        public Uri Uri { get; set; }
    }
}

using System.ComponentModel;

namespace VideoGame.Api.RequestForms;

public class UserForm
{
    [DefaultValue("john-doe")]
    public string Username { get; set; } = string.Empty;

    [DefaultValue("password")]
    public string Password { get; set; } = string.Empty;
}

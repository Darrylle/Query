using System;
using Environment;

public class General
{
	public General()
	{
          
	}

    /// <summary>
    /// Returns Windows lowercase network user login.
    /// </summary>
    /// <returns></returns>
    public string GetNW_Login()
    {
        return UserName.ToLower();
    }
}

# Canducci ReCAPTCHA

[![Travis](https://img.shields.io/travis/netdragoon/ReCaptchaNet.svg)](https://github.com/netdragoon/ReCaptchaNet)
[![NuGet](https://img.shields.io/nuget/dt/CanducciReCaptchaMvc.svg?style=plastic&label=downloads)](https://www.nuget.org/packages/CanducciReCaptchaMvc/)
[![NuGet](https://img.shields.io/nuget/v/CanducciReCaptchaMvc.svg?style=plastic&label=version)](https://www.nuget.org/packages/CanducciReCaptchaMvc/)

##NUGET

```Csharp
PM> Install-Package CanducciReCaptchaMvc

```

##How to?

In web.config add these 4 keys referring to Google Api (`Captcha-Site-Key`, `Captcha-Secrety-Key`, `Captcha-Site-Verify-Url` and `Captcha-Api-Url`). 
Make your registration in https://www.google.com/recaptcha/intro/index.html site and add the settings the _site key_(Captcha-Site-Key) and _secret key_(Captcha-Secrety-Key).

```Csharp
<configuration>
  <appSettings>
    ...
    <add key="Captcha-Site-Key" value=""/>
    <add key="Captcha-Secrety-Key" value=""/>
    <add key="Captcha-Site-Verify-Url" value="https://www.google.com/recaptcha/api/siteverify"/>
    <add key="Captcha-Api-Url" value="https://www.google.com/recaptcha/api.js"/>  
  </appSettings>
```

Use namespace `using Canducci.ReCAPTCHA;` 

###Controller
```Csharp
[HttpGet()]
public ActionResult Site()
{            
	return View();
}

[HttpPost()]
public ActionResult Site(ReCaptchaResponse ReCaptchaResponse)
{
	
	if (ReCaptchaResponse.Success)
	{
		//validation passed    
	}
	else
	{
		//validation errors
	}

	return View();
}

```

###View

_In html tag in the Head call the razor method_ `Html.ReCaptchaScript`

```Html
<head>
    ....
    @Html.ReCaptchaScript(Render.Onload, ReCaptchaLanguage.Portuguese_Brazil)    
</head>
```

_Body call the razor method_ `Html.ReCaptcha()`

```Html
<form method="post">            
    <div style="height:100px;">
        @Html.ReCaptcha()
    </div>
    <button class="btn btn-primary">Send</button>
</form>
```




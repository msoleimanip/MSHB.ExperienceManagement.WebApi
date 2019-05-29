﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using MSHB.ExperienceManagement.Shared.Common.Captcha.Providers;

namespace MSHB.ExperienceManagement.Shared.Common.Captcha
{
    /// <summary>
    /// Tag helper attributes
    /// </summary>
    public class CaptchaTagHelperHtmlAttributes
    {
        /// <summary>
        /// The back-color of the captcha. It's default value is string.Empty.
        /// </summary>
        [HtmlAttributeName("asp-back-color")]
        public string BackColor { set; get; } = "";

        /// <summary>
        /// The font-name of the captcha. It's default value is Tahoma.
        /// </summary>
        [HtmlAttributeName("asp-font-name")]
        public string FontName { set; get; } = "Tahoma";

        /// <summary>
        /// The font-size of the captcha. It's default value is 12.
        /// </summary>
        [HtmlAttributeName("asp-font-size")]
        public float FontSize { set; get; } = 12;

        /// <summary>
        /// The fore-color of the captcha. It's default value is #1B0172.
        /// </summary>
        [HtmlAttributeName("asp-fore-color")]
        public string ForeColor { set; get; } = "#1B0172";

        /// <summary>
        /// The language of the captcha. It's default value is Persian.
        /// </summary>
        [HtmlAttributeName("asp-captcha-generator-language")]
        public Language Language { set; get; } = Language.Persian;

        /// <summary>
        /// The max value of the captcha. It's default value is 9000.
        /// </summary>
        [HtmlAttributeName("asp-captcha-generator-max")]
        public int Max { set; get; } = 9000;

        /// <summary>
        /// نوع خروجی به صورت عددی یا حروفی باشد
        /// </summary>
        [HtmlAttributeName("asp-captcha-generator-output-type")]
        public OutputType OutputType { set; get; } = OutputType.InString;

        /// <summary>
        /// فقط قسمت تصویر را بسازد و باکس ورودی و دکمه ی رفرش نسازد
        /// </summary>
        [HtmlAttributeName("asp-captcha-generator-image-only")]
        public bool ImageOnly { set; get; } = false;

        /// <summary>
        /// The min value of the captcha. It's default value is 1.
        /// </summary>
        [HtmlAttributeName("asp-captcha-generator-min")]
        public int Min { set; get; } = 1;

        /// <summary>
        /// The placeholder value of the captcha. It's default value is `کد امنیتی به رقم`.
        /// </summary>
        [HtmlAttributeName("asp-placeholder")]
        public string Placeholder { set; get; } = "کد امنیتی به رقم";

        /// <summary>
        /// The css class of the captcha. It's default value is `text-box single-line form-control col-md-4`.
        /// </summary>
        [HtmlAttributeName("asp-text-box-class")]
        public string TextBoxClass { set; get; } = "text-box single-line form-control col-md-4";

        /// <summary>
        /// The text-box-template of the captcha. It's default value is `<div class='input-group col-md-4'><span class='input-group-addon'><span class='glyphicon glyphicon-lock'></span></span>{0}</div>`.
        /// </summary>
        [HtmlAttributeName("asp-text-box-template")]
        public string TextBoxTemplate { set; get; } =
            @"<div class='input-group col-md-4'><span class='input-group-addon'><span class='glyphicon glyphicon-lock'></span></span>{0}</div>";

        /// <summary>
        /// The validation-error-message of the captcha. It's default value is `لطفا کد امنیتی را به رقم وارد نمائید`.
        /// </summary>
        [HtmlAttributeName("asp-validation-error-message")]
        public string ValidationErrorMessage { set; get; } = "لطفا کد امنیتی را به رقم وارد نمائید";

        /// <summary>
        /// The validation-message-class of the captcha. It's default value is `text-danger`.
        /// </summary>
        [HtmlAttributeName("asp-validation-message-class")]
        public string ValidationMessageClass { set; get; } = "text-danger";

        /// <summary>
        /// The refresh-button-class of the captcha. It's default value is `glyphicon glyphicon-refresh btn-sm`.
        /// </summary>
        [HtmlAttributeName("asp-refresh-button-class")]
        public string RefreshButtonClass { set; get; } = "glyphicon glyphicon-refresh btn-sm";

        /// <summary>
        /// The Captcha Token
        /// </summary>
        [HtmlAttributeNotBound]
        public string CaptchaToken { set; get; }
    }
}
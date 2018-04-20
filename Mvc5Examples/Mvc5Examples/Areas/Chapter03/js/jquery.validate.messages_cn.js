/// <autosync enabled="false" />

jQuery.extend(jQuery.validator.messages, {
    required: "不能为空。",
    minlength: jQuery.validator.format("请至少输入{0}个字符。"),
    maxlength: jQuery.validator.format("请输入不超过{0}个字符的字符串。"),
    rangelength: jQuery.validator.format("输入的字符数必须在{0}到{1}之间"),
    min: jQuery.validator.format("请输入大于等于{0}的数。"),
    max: jQuery.validator.format("请输入小于等于{0}的数。"),
    range: jQuery.validator.format("请输入{0}到{1}之间的数。"),
    digits: "请输入整数。",
    number: "请输入一个有效的数。",
    date: "请输入一个有效的日期。",
    dateISO: "请输入一个有效的（ISO）日期。",
    email: "请输入一个有效的电子邮件地址。",
    url: "请输入一个有效的URL。",
    creditcard: "请输入有效的信用卡号。",
    equalTo: "输入信息和上一个不一致。",
    accept: "请输入可接受的字符。",
    remote: "服务器验证失败。",
});
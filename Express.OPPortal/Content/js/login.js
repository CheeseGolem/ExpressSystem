//1.0 JS
//onload = function () {
//    document.getElementById('imgCaptcha').onclick = function () {
//        this.src = "/Captcha/CaptchaHandler.ashx?r=" + Math.random();
//    }
//}

//2.0 JQ 刷新验证码
//$(function () {
//    $('#imgCaptcha').click(function () {
//        $(this).attr('src', "/Captcha/CaptchaHandler.ashx?r=" + Math.random());
//    });
//});       

//刷新验证码
function refreshCaptcha(obj) {
    $(obj).attr('src', "/Login/CaptchaHandler.ashx?r=" + Math.random());
}

//键盘事件
//$(function () {
//    document.getElementById('txtUid').onkeydown = function (e) {
//        return submitLoginRequest(e);
//    }
//    document.getElementById('txtPwd').onkeydown = function (e) {
//        return submitLoginRequest(e);
//    }
//    document.getElementById('txtCaptcha').onkeydown = function (e) {
//        return submitLoginRequest(e);
//    }
//});



//$("#txtUid,#txtPwd,#txtCaptcha").click(function (submitLoginRequest) {
//    this.select();
//})

//function selectS(s) {
//    return document.querySelectorAll(s);
//}
//[].forEach.call(selectS('#txtUid,#txtPwd,#txtCaptcha'), function (e) {
//    e.onmousedown = function (submitLoginRequest) {
//        this.select();
//    }
//})

//回车登录
function submitLoginRequest(e) {
    e = e || window.event;//浏览器兼容性判断
    if (e.keyCode == 13) {
        return login();
    }
    return true;
}

function login() {
    //非空验证 
    if (!checkInputInfo()) {
        return false;//取消元素的默认事件（点击事件）
    }

    //通过验证，隐藏提示语
    $('.tip').css('display', 'none');//显示
    $('.tip').html('');

    //密码加密
    var pwd = hex_md5($('#txtPwd').val()).toUpperCase();
    //var postData = {};//JS对象
    //var postData = '{}';//JSON字符串转JS对象

    //var json1 = '{id:100,name:"张三"}';
    //var objJson1 = eval('(' + json1 + ')');//可以转换不标准的jSON字符串

    //var json2 = '{"id":100,"name":"张三"}';//标准格式的JSON 属性名两边必须加上双引号
    //JSON.parse(json2);

    var postData = {
        UserName: $('#txtUid').val(),
        Password: pwd,//MD5加密后的密码
        Captcha: $('#txtCaptcha').val(),
        IsAutoLogin: $('#chkAutoLogin').get(0).checked,
    };

    //发送AJAX请求
    $.ajax({
        url: '/Login/LoginHandler.ashx',
        type: 'post',
        dataType: 'json',
        data: postData,
        success: function (data) {
            if (data.Status != 0) {
                $('.tip').css('display', 'inline');
                $('.tip').html(data.Msg);
                refreshCaptcha($('#imgCaptcha'));
            } else {
                window.location.href = '/ExpressInfo/List.aspx';
            }
        }//相应成功的回调函数
    });
    return true;
}

//验证输入项
function checkInputInfo() {
    var flag = true;
    var msg = '';//错误消息

    //非空验证
    if ($('#txtCaptcha').val() == "") {
        flag = false;
        msg = '请输入验证码';
    }

    if ($('#txtPwd').val() == "") {
        flag = false;
        msg = '请输入密码';
    }

    if ($('#txtUid').val() == "") {
        flag = false;
        msg = '请输入用户名';
    }

    if (!flag) {
        $('.tip').css({
            display: 'inline',
        });//显示
        $('.tip').html(msg);
    }
    return flag;
}
//判断键盘输入的字符是否为数字
function isNumber(e) {
    //兼容性判断
    e = e || window.event;

    //
    var reg = /[0-9]/;
    return reg.test(e.key) || e.keyCode == 8 || e.keyCode == 35 || e.keyCode == 36 || e.keyCode == 37 || e.keyCode == 38 || e.keyCode == 39 || e.keyCode == 40 || e.keyCode == 45 || e.keyCode == 46;

    //BackSpace 8
    //Delete 46

    //End 35
    //Home 36

    //Left Arrow 37
    //Up Arrow 38
    //Right Arrow 39
    //Down Arrow 40

    //Insert 45
}

function isPasteNum(e) {
    e = e || window.event;

    var clipBoardData = e.clipboardData || window.clipboardData;//兼容性判断
    var reg = /^\d+$/;
    var txt = clipBoardData.getData("text");//text表示以文本的方式获取

    return reg.test(txt);
}
function ShowMessage(msg) {
    /// <summary>弹出对话框</summary>
    /// <param name="msg" type="String">在对话框中显示的信息</param>
    alert(msg);
}

function DrawCanvas(id) {
    /// <summary>在canvas元素中绘制图形</summary>
    /// <param name="id" type="String">canvas元素的id名称</param>
    var canvas1 = document.getElementById(id);
    if (canvas1 != null) {
        var ctx = canvas1.getContext('2d');
        // 定义渐变图形
        var sky = ctx.createLinearGradient(0, 0, 0, canvas1.clientHeight);
        sky.addColorStop(0, "#00ABEB");
        sky.addColorStop(1, "white");
        // 绘制图形
        ctx.fillStyle = sky;
        ctx.fillRect(0, 0, canvas1.clientWidth, canvas1.clientHeight);
    }
}

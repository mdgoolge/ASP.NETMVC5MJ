var My3d = {};

My3d.Width = function(){
    /// <summary>获取WebGL容器的宽度</summary>
    return window.innerWidth;
};

My3d.Height = function () {
    /// <summary>获取WebGL容器的高度</summary>
    return window.innerHeight;
};

My3d.aspect = function (){
    /// <summary>获取WebGL容器的纵横比</summary>
    return window.innerWidth / window.innerHeight;
};

My3d.HalfWidth = function () {
    /// <summary>WebGL容器的一半高度</summary>
    return window.innerWidth / 2;
};

My3d.HalfHeight = function () {
    /// <summary>WebGL容器的一半高度</summary>
    return window.innerHeight / 2;
};

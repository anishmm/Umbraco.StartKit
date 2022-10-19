jssor_1_slider_init = function () {
    var jssor_1_SlideoTransitions = [];

    var jssor_1_options =
    {
        $AutoPlay: 1,
        $Idle: 2000,
        $CaptionSliderOptions:
        {
            $Class: $JssorCaptionSlideo$,
            $Transitions: jssor_1_SlideoTransitions,
            $Breaks:
                [
                    [{ d: 2000, b: 1000 }]
                ]
        },
        $ArrowNavigatorOptions:
        {
            $Class: $JssorArrowNavigator$
        },
        $BulletNavigatorOptions:
        {
            $Class: $JssorBulletNavigator$
        }
    };
    var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

    /*#region responsive code begin*/

    function ScaleSlider() {
        var bodyWidth = document.body.clientWidth;
        if (bodyWidth) {
            jssor_1_slider.$ScaleWidth(Math.min(bodyWidth, 1920));
        }
        else {
            window.setTimeout(ScaleSlider, 30);
        }
    }

    ScaleSlider();
    $Jssor$.$AddEvent(window, "load", ScaleSlider);
    $Jssor$.$AddEvent(window, "resize", ScaleSlider);
    $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
    /*#endregion responsive code end*/
};

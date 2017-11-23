(function (app) {
    'use strict';

    app.directive('ngElevateZoom', ngElevateZoom);
    function ngElevateZoom() {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                console.log("Linking")

                //Will watch for changes on the attribute
                attrs.$observe('zoomImage', function () {
                    linkElevateZoom();
                })

                function linkElevateZoom() {
                    //Check if its not empty
                    if (!attrs.zoomImage) return;
                    element.attr('data-zoom-image', attrs.zoomImage);
                    $(element).elevateZoom();
                }

                linkElevateZoom();

            }
        };
    }
})(angular.module('common.ui'));
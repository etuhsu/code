(function(){function e(e,t){for(var n in t)t.hasOwnProperty(n)&&(e[n]=t[n]);return e}if(!monitor)return;var t={};monitor.setGlobalParams=function(e,n){t[e]=escape(n)};var n=monitor.data.getBase;monitor.data.getBase=function(){var r=n();return e(r,t),r}})(),function(){var e,t,n=/(?:^|;\s)Y=(.*?);/,r=function(e,t){var n=new RegExp("(^|&)"+e+"=([^&]*)(&|$)","i"),r=location.search.substr(1).match(n);return r!==null?unescape(r[2]):t||null};t=r("src");var i=document.cookie.match(n);i&&i[1]&&(e=i[1].split("_")[0]),e&&monitor.setGlobalParams("yid",e),t&&monitor.setGlobalParams("src",t)}();
(function(n){function s(o){return t=n(o.data.el),t.blur(),r=i?f(o).x:f(o).y,u=(i?t.width():t.height())-r,t.css("opacity",.25),n(document).mousemove(h).mouseup(e),!1}function h(n){var h=i?f(n).x:f(n).y,s=u+h;return r>=h&&(s-=5),r=h,s=Math.max(o,s),i?t.width(s+"px"):t.height(s+"px"),s<o&&e(n),!1}function e(){n(document).unbind("mousemove",h).unbind("mouseup",e);t&&(t.css("opacity",1),t.focus());t=null;u=null;r=0}function f(n){return{x:n.clientX+document.documentElement.scrollLeft,y:n.clientY+document.documentElement.scrollTop}}var t,u,r=0,o=32,i=!1;n.fn.TextAreaResizer=function(r){i=r;var f=document.activeElement;return this.each(function(){t=n(this).addClass("processed");u=null;i?n(this).wrap('<div class="resizable-control"><div class="wrap"><\/div><\/div>').parent().parent().append(n('<div class="grippie"> <\/div>').bind("mousedown",{el:this},s)):n(this).wrap('<div class="resizable-control"><span><\/span><\/div>').parent().append(n('<div class="grippie"> <\/div>').bind("mousedown",{el:this},s));var r=n("div.grippie",n(this).parent())[0];r&&(i?r.style.marginBottom=r.offsetHeight-n(this)[0].offsetHeight+"px":r.style.marginRight=r.offsetWidth-n(this)[0].offsetWidth+"px");f&&f.focus()})}})(jQuery);
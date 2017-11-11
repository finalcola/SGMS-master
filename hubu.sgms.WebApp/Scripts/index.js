		$(function(){
	$(".rollpicshow").jCarouselLite({
		auto: 2000, /*自动播放间隔时间*/
		speed: 500, /*速度*/
		btnNext:".next",/*向前滚动*/
		btnPrev:".prev",/*向后滚动*/
		visible:3/*显示数量*/
	})});
/*导航轮播图*/
$('.carousel-caption').hide();
$('.item').hover(
	function(){
		$(this).find('.carousel-caption').slideDown();
	},
	function(){
		$(this).find('.carousel-caption').slideUp();
	}
);

/*通知公告*/
 !function ($) {
			$.Huimarquee = function(height,speed,delay){
				var scrollT;
				var pause = false;
				var ScrollBox = document.getElementById("marquee");
				if(document.getElementById("holder").offsetHeight <= height) return;
				var _tmp = ScrollBox.innerHTML.replace('holder', 'holder2')
				ScrollBox.innerHTML += _tmp;
				ScrollBox.onmouseover = function(){pause = true}
				ScrollBox.onmouseout = function(){pause = false}
				ScrollBox.scrollTop = 0;
				var start = function(){
					scrollT = setInterval(scrolling,speed);
					if(!pause) ScrollBox.scrollTop += 2}
				var scrolling = function(){
					if(ScrollBox.scrollTop % height != 0){
						ScrollBox.scrollTop += 2;
						if(ScrollBox.scrollTop >= ScrollBox.scrollHeight/2) ScrollBox.scrollTop = 0}
					else{
						clearInterval(scrollT);
						setTimeout(start,delay)}
				}
				setTimeout(start,delay)}
		}(window.jQuery);
		$.Huimarquee(60,100,10);/*移动高度,移动速度,间隔时间*/

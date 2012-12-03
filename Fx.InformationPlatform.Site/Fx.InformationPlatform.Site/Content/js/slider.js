// JavaScript Document

function Control_btn()
{
	var get_li=document.getElementById("slider").getElementsByTagName("li");
	var l_id=document.getElementById("left_btns");
	var r_id=document.getElementById("right_btns");
	var count_li=get_li.length;
	for(var i=0;i<count_li;i++)
	{
		document.getElementById("slider").getElementsByTagName("li")[i].onmouseover=function (){
			s_h_on();
			};
		document.getElementById("slider").getElementsByTagName("li")[i].onmouseout=function (){
			s_h_off();
			};
		}
	set_fc();
	}
	
function set_fc()
{
	var l_id=document.getElementById("left_btns");
	var r_id=document.getElementById("right_btns");
	l_id.onmouseover = function () {
	        l_id.style.backgroundImage = 'url(http://image.yingtao.co.uk/mouse_on_bg.png)';
		l_id.style.display='block';
		r_id.style.display='block';
		}
	l_id.onmouseout=function (){
	    l_id.style.backgroundImage = 'url(http://image.yingtao.co.uk/mouse_off_bg.png)';
		l_id.style.display='none';
		r_id.style.display='none';
		}
	r_id.onmouseover=function (){
	    r_id.style.backgroundImage = 'url(http://image.yingtao.co.uk/mouse_on_bg.png)';
		r_id.style.display='block';
		l_id.style.display='block';
		}
	r_id.onmouseout=function (){
	    r_id.style.backgroundImage = 'url(http://image.yingtao.co.uk/mouse_off_bg.png)';
		r_id.style.display='none';
		l_id.style.display='none';
		}
	}

function s_h_off()
{
	var l_id=document.getElementById("left_btns");
	var r_id=document.getElementById("right_btns");
	l_id.style.display='none';
	r_id.style.display='none';
	}
	
function s_h_on()
{
	var l_id=document.getElementById("left_btns");
	var r_id=document.getElementById("right_btns");
	l_id.style.display='block';
	r_id.style.display='block';
	}


var Effect = (function() {
	
	var Slider = function(o) {
		this.setting      = typeof o === 'object' ? o : {};
		this.target       = this.setting.target || 'slider';
		this.showMarkers  = this.setting.showMarkers || false;
		this.showControls = this.setting.showControls || false;
		this.timer        = null;
		this.currentTime  = null;
		this.ms           = 35;
		this.autoMs       = 3000;
		this.iTarget      = 0;
		this.nextTarget   = 0;
		this.speed        = 0;
		
		this.init();
		this.handleEvent();
	};
	
	Slider.prototype = {
		init: function() {
			this.obj      = document.getElementById(this.target);
			this.oUl      = this.obj.getElementsByTagName('ul')[0];
			this.aUlLis   = this.oUl.getElementsByTagName('li');
			this.width    = this.aUlLis[0].offsetWidth;
			this.number   = this.aUlLis.length;
			
			this.oUl.style.width = this.width * this.number + 'px';
			
			if(this.showMarkers) {
				var oDiv = document.createElement('div');
				var aLis = [];
				for(var i = 0; i < this.number; i++) {
					aLis.push('<li>'+ (i+1) +'<\/li>');
				};
				oDiv.innerHTML = '<ol>'+ aLis.join('') +'<\/ol>';
				this.obj.appendChild(oDiv.firstChild);
				this.aLis = this.obj.getElementsByTagName('ol')[0].getElementsByTagName('li');
				this.aLis[0].className = 'active';
				var oUI= document.getElementsByTagName('ul')[0];
				oDiv = null;
			};
			
			if(this.showControls) {
				this.oPrev = document.createElement('p');
				this.oNext = document.createElement('p');
				this.oPrev.className = 'prev';
				this.oPrev.innerHTML = '';
				this.oNext.className = 'next';
				this.oNext.innerHTML = '';
				document.getElementById("left_btns").appendChild(this.oPrev);
				document.getElementById("right_btns").appendChild(this.oNext);
				
			};
			
		},

			
		handleEvent: function() {
			var that = this;
			
			this.currentTime = setInterval(function() {
				that.autoPlay();
			}, this.autoMs);
			
			this.addEvent(this.obj, 'mouseover', function() {
				clearInterval(that.currentTime);
			});
			
			this.addEvent(this.obj, 'mouseout', function() {
				that.currentTime = setInterval(function() {
					that.autoPlay();
				}, that.autoMs);
			});
			
			if(this.showMarkers) {
				for(var i = 0; i < this.number; i++) {
					var el = this.aLis[i];
					(function(index) {
						that.addEvent(el, 'mouseover', function() {
							that.goTime(index);
							var oUI= document.getElementsByTagName('ul')[0];
						});
					})(i);
				};
			};
			
			if(this.showControls) {
				this.addEvent(this.oPrev, 'click', function() {
					that.fnPrev();
				});
				this.addEvent(this.oNext, 'click', function() {
					that.autoPlay();
				});
			};
			
		},
		
		addEvent: function(el, type, fn) {
			if(window.addEventListener) {
				el.addEventListener(type, fn, false);
			}
			else if(window.attachEvent) {
				el.attachEvent('on' + type, fn);
			};
		},
		
		fnPrev: function() {
			this.nextTarget--;
			if(this.nextTarget < 0) {
				this.nextTarget = this.number - 1;
			};
			this.goTime(this.nextTarget);
		},
		
		autoPlay: function() {
			this.nextTarget++;
			if(this.nextTarget >= this.number) {
				this.nextTarget = 0;
			};
										var oUI= document.getElementsByTagName('ul')[0];
			this.goTime(this.nextTarget);
		},
		
		goTime: function(index) {
			var that = this;
			
			if(this.showMarkers) {
				for(var i = 0; i < this.number; i++) {
					i == index ? this.aLis[i].className = 'active' : this.aLis[i].className = '';
			        
					//alert(titlesd);
				};
			};
			
			this.iTarget = -index * this.width;
			if(this.timer) {
				clearInterval(this.timer);
			};
			this.timer = setInterval(function() {
				that.doMove(that.iTarget);
			}, this.ms);
		},
		
		doMove: function(target) {
			this.oUl.style.left = this.speed + 'px';
			this.speed += (target - this.oUl.offsetLeft) / 3;
			if(Math.abs(target - this.oUl.offsetLeft) === 0) {
				this.oUl.style.left = target + 'px';
				clearInterval(this.timer);
				this.timer = null;
			};
		}
	};
	
	return {
		
		slider: function(o) {
			var tt = new Slider(o);
		}
	};
})();
Effect.slider({
	'targetElement': 'slider',
	'showMarkers': false,
	'showControls': true
});

















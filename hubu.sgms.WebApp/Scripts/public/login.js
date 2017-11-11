$(document).ready(function() {
	//验证码
$.idcode.setCode();	
$("#btns").click(function (){
	IsBy = $.idcode.validateCode(); 
	console.log(IsBy);
});
//$('#btns').click();
// 表单验证
$('input[name=username]').blur(function(){
	val=this.value;
	
	//if(!val.match(/^[a-zA-z]\w{3,15}$/)){
	if(!val.match(/^[1-9]{1}\d{5,15}$/)){
		$(this).data({'s':0});
		$(this).next().show();	
		$(this).next().next().hide();
	}else{
		$(this).data({'s':1});
		$(this).next().hide();	
		$(this).next().next().show();
	}
});
$('input[name=password]').blur(function(){
	val=this.value;

	if(!val.match(/^[u0391-uFFE5w]+$/)){
		$(this).data({'s':0});
		$(this).next().show();	
		$(this).next().next().hide();
	}else{
		$(this).data({'s':1});
		$(this).next().hide();	
		$(this).next().next().show();
	}
});

$('input[name=yzm]').blur(function(){
	if(IsBy==false){
		$(this).data({'s':0});
		$(this).next().next().show();
		$(this).next().next().next().hide();
	}else{
		$(this).data({'s':1});
		$(this).next().next().hide();
		$(this).next().next().next().show();
	}
});
$('form').submit(function(){
	$('.auth').blur();

	tot=0;

	$('.auth').each(function(){
		tot+=$(this).data('s');
	});

	if(tot!=3){
		return false;
	}
});
	
});
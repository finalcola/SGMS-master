//JavaScript代码区域
layui.use('element', function(){
  var element = layui.element;
  
});
//点击左边显示右边对应内容
$('.menu .z_item').click(function(){
	idx=$(this).index('.menu .z_item');

	$('.info .z_content').eq(idx).show();
	$('.info .z_content').not($('.info .z_content').eq(idx)).hide();
});

$(document).ready(function() {
	    $('#defaultForm').formValidation({
	        message: '信息填写错误，请重新输入',
	        excluded: ':disabled',
	        icon: {
	            valid: 'glyphicon glyphicon-ok',
	            invalid: 'glyphicon glyphicon-remove',
	            validating: 'glyphicon glyphicon-refresh'
	        },
	        fields: {           
                student_name: {
	                message: '信息格式填写错误',
	                validators: {
	                    notEmpty: {
	                        message: '信息不能为空'
	                    },
	                    stringLength: {
	                        min: 3,
	                        max: 12,
	                        message: '用户名长度必须在3~12位之间'
	                    },
	                    regexp: {
	                        regexp: /^[u0391-uFFE5w]+$/,
	                        message: '用户名只能包括中文字、英文字母、数字和下划线'
	                    }
	                }
	            },
                student_id_card: {
	            	validators: {
	                    notEmpty: {
	                        message: '信息不能为空'
	                    },
	                    regexp: {
	                        regexp: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/,
	                        message: '身份证号输入错误'
	                    }
	                }
	            },
	            email: {
	                validators: {
	                   	notEmpty: {
	                        message: '信息不能为空'
	                    },
	                    regexp: {
	                        regexp: /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/,
	                        message: '邮箱输入错误'
	                    }
	                }
	            },
	          
                student_phone: {
	                validators: {              
	                    notEmpty: {
	                        message: '信息不能为空'
	                    },
	                    
	                    regexp: {
	                        regexp: /^1(3|4|5|7|8)\d{9}$/,
	                        message: '手机号码格式错误'
	                    }
	                }
	            }
	        }
	    }).on('err.form.fv', function(e) {
	        console.log('error');

	        // Active the panel element containing the first invalid element
	        var $form         = $(e.target),
	            validator     = $form.data('formValidation'),
	            $invalidField = validator.getInvalidFields().eq(0),
	            $collapse     = $invalidField.parents('.collapse');

	        $collapse.collapse('show');
	    });
	});
new PCAS("user.province", "user.city", "user.area", "湖北省", "武汉市", "武昌区");

//修改学生信息
function changeStuInfo() {
    var province = $("#province").val();
    var city = $("#city").val();
    var area = $("#area").val();
    var location = province + city + area;

    console.log(location);

    $.ajax({
        url: "/Student/ChangeInfo",
        method: "post",
        data: {
            student_address: location,
            student_name: $("#student_name").val(),
            student_id_card: $("#student_id_card").val(),
            student_phone: $("#student_phone").val(),
            student_email: $("#student_email").val(),
            student_other: $("#student_other").val()
        },
        success: function (data) {
            if (data.status == 1) {
                alert("修改成功!");
            }
            else {
                alert("failed!");
            }
        }
    });
}
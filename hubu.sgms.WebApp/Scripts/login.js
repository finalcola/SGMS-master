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
	            username: {
	                message: '信息格式填写错误',
	                validators: {
	                    notEmpty: {
	                        message: '信息不能为空'
	                    }
	                   /* stringLength: {
	                        min: 3,
	                        max: 12,
	                        message: '用户名长度必须在3~12位之间'
	                    },*/
	                    regexp: {
	                        regexp:/\w{5,20}$/,
	                        message: '学号不正确，请重新输入'
	                    }
	                }
	            },
	            
	            password: {
	                validators: {
	                    notEmpty: {
	                        message: '密码不能为空'
	                    },
	                    /*different: {
	                        field: 'username',
	                        message: '密码不能和用户名一样'
	                    }*/
	                }
	            },	           
	           
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
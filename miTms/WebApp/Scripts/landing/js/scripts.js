
function scroll_to_class(element_class, removed_height) {
	var scroll_to = $(element_class).offset().top - removed_height;
	if($(window).scrollTop() != scroll_to) {
		$('html, body').stop().animate({scrollTop: scroll_to}, 0);
	}
}

function bar_progress(progress_line_object, direction) {
	var number_of_steps = progress_line_object.data('number-of-steps');
	var now_value = progress_line_object.data('now-value');
	var new_value = 0;
	if(direction == 'right') {
		new_value = now_value + ( 100 / number_of_steps );
	}
	else if(direction == 'left') {
		new_value = now_value - ( 100 / number_of_steps );
	}
	progress_line_object.attr('style', 'width: ' + new_value + '%;').data('now-value', new_value);
}

jQuery(document).ready(function() {
	
    /*
        Fullscreen background
    */
   // $.backstretch("content/landing/img/backgrounds/1.jpg");
    
    //$('#top-navbar-1').on('shown.bs.collapse', function(){
    //	$.backstretch("resize");
    //});
    //$('#top-navbar-1').on('hidden.bs.collapse', function(){
    //	$.backstretch("resize");
    //});
    
    /*
        Form f1
    */
    var errorClass = 'invalid-feedback';
    var errorElement = 'small';
    var $f1 = $('#carrier_form').validate({
        errorClass: errorClass,
        errorElement: errorElement,
        highlight: function (element) {
            //$(element).parent().removeClass('is-valid').addClass("is-invalid");
            $(element).removeClass('is-valid').addClass("is-invalid");
        },
        unhighlight: function (element) {
            //$(element).parent().removeClass("is-invalid").addClass('is-valid');
            $(element).removeClass("is-invalid").addClass('is-valid');
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element);
        },
        rules: {
            
            Email: {
                required: true,
                maxlength: 50,
                email: true,
                remote: {
                    url: "/Account/ValidEmail",
                    type: "post",
                    dataType: 'json'
                }
            },
            Password: {
                required: true,
                maxlength: 16,
                minlength: 3
            },
            PasswordConfirm: {
                required: true,
                maxlength: 16,
                minlength: 3,
                equalTo: '#cPassword'
            },
            CarrierName: {
                required: true,
                maxlength: 20,
                remote: {
                    url: "/Account/ValidCarrierName",
                    type: "post",
                    dataType: 'json'
                }
            },
            CarrierType: {
                required: true,
                maxlength: 20
            },
            ContactName: {
                required: true,
                maxlength: 20
            },
            ContactMobileTelephoneNumber: {
                required: true,
                maxlength: 18,
                minlength:11,
                digits: true
            },
            CountrySubdivisionCode: {
                required: true,

            },
            RegisteredAddress: {
                required: true,
                maxlength: 2556
            },
            RegisteredCapital: {
                required: true,
                digits: true
            },
            UnifiedSocialCreditldentifier: {
                required: false,
                maxlength: 18
            },
            PermitNumber: {
                required: true,
                maxlength: 18
            },
            BusinessScope: {
                required: true,
                maxlength: 256
            },
            RegisteredCapital: {
                required: true,
                digits: true
            },
            VehicleClassificationCode: {
                required: true, 
            },
            LicenseplateTypeCode: {
                required: true,
            },
            VehicleNumber: {
                required: true,
                maxlength: 8,
                minlength: 7,
                remote: {
                    url: "/Account/ValidVehicleNumber",
                    type: "post",
                    dataType: 'json'
                }
            },
            RoadTransportCertificateNumber: {
                required: true,
                maxlength: 18
            },
            VehicleLadenWeight: {
                required: true,
                digits: true
            },
            VehicleTonnage: {
                required: true,
                digits: true
            },
            VehicleLength: {
                required: false,
                digits: true
            },
            VehicleLicensePlateColor: {
                required: true,
            },
            VehicleWidth: {
                required: false,
                digits: true
            },
            VehicleHeight: {
                required: false,
                digits: true
            },
            DriverName: {
                required: true,
                maxlength: 18
            },
            DriverGender: {
                required: true,
                
            },
            IdentityDocumentNumber: {
                required: true,
                maxlength: 18,
                minlength:17
            },
            MobileTelephoneNumber: {
                required: true,
                maxlength: 18,
                minlength: 11
            },
            QualificationCertificateNumber: {
                required: true,
                maxlength: 18
            },
        },
        messages: {
            Email: {
                remote: "Email already in use"
            },
            CarrierName: {
                remote: "CarrierName already in use"
            },
            VehicleNumber: {
                remote: "VehicleNumber already in use"
            }
        }

    });


    $('.f1 fieldset:first').fadeIn('slow');
    
    //$('.f1 input[type="text"], .f1 input[type="password"], .f1 textarea').on('focus', function() {
    //	$(this).removeClass('input-error');
    //});
    
    // next step
    $('.f1 .btn-next').on('click', function() {
    	var parent_fieldset = $(this).parents('fieldset');
    	var next_step = true;
    	// navigation steps / progress steps
    	var current_active_step = $(this).parents('.f1').find('.f1-step.active');
    	var progress_line = $(this).parents('.f1').find('.f1-progress-line');
    	
    	// fields validation
        parent_fieldset.find('input[type="text"], input[type="password"],input[type="email"],select').each(function() {
            if ($(this).valid() == false)  {
    			
    			next_step = false;
    		}
    		else {
    			
    		}
    	});
    	// fields validation
    	
    	if( next_step ) {
    		parent_fieldset.fadeOut(400, function() {
    			// change icons
    			current_active_step.removeClass('active').addClass('activated').next().addClass('active');
    			// progress bar
    			bar_progress(progress_line, 'right');
    			// show next step
	    		$(this).next().fadeIn();
	    		// scroll window to beginning of the form
    			scroll_to_class( $('.f1'), 20 );
	    	});
    	}
    	
    });
    
    // previous step
    $('.f1 .btn-previous').on('click', function() {
    	// navigation steps / progress steps
    	var current_active_step = $(this).parents('.f1').find('.f1-step.active');
    	var progress_line = $(this).parents('.f1').find('.f1-progress-line');
    	
    	$(this).parents('fieldset').fadeOut(400, function() {
    		// change icons
    		current_active_step.removeClass('active').prev().removeClass('activated').addClass('active');
    		// progress bar
    		bar_progress(progress_line, 'left');
    		// show previous step
    		$(this).prev().fadeIn();
    		// scroll window to beginning of the form
			scroll_to_class( $('.f1'), 20 );
    	});
    });
    
    // submit
    $('.f1').on('submit', function(e) {
        if ($f1.valid() == false) {
            e.preventDefault();
        }
        else {
         }

    });

    /*
        Form f2
    */

   
    var $f2 = $('#shipper_form').validate({
        errorClass: errorClass,
        errorElement: errorElement,
        highlight: function (element) {
            //$(element).parent().removeClass('is-valid').addClass("is-invalid");
            $(element).removeClass('is-valid').addClass("is-invalid");
        },
        unhighlight: function (element) {
            //$(element).parent().removeClass("is-invalid").addClass('is-valid');
            $(element).removeClass("is-invalid").addClass('is-valid');
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element);
        },
        rules: {
            Email: {
                required: true,
                maxlength: 50,
                email: true,
                remote: {
                    url: "/Account/ValidEmail",
                    type: "post",
                    dataType: 'json'
                }
            },
            Password: {
                required: true,
                maxlength: 16,
                minlength: 3
            },
            PasswordConfirm: {
                required: true,
                maxlength: 16,
                minlength: 3,
                equalTo: '#sPassword'
            },
            ShipperName: {
                required: true,
                maxlength: 20,
                remote: {
                    url: "/Account/ValidShipperName",
                    type: "post",
                    dataType: 'json'
                }
            },
            ShipperType: {
                required: true,
                maxlength: 20
            },
            ContactName: {
                required: true,
                maxlength: 20
            },
            ContactMobileTelephoneNumber: {
                required: true,
                maxlength: 18,
                minlength: 11,
                digits: true
            },
            ContactTelephoneNumber: {
                required: false,
                maxlength: 18,
                minlength: 6,
                digits: true
            },
            PersonalIdentityDocument: {
                required: true,
                maxlength: 18,
                minlength: 17
            },
            RegisteredAddress: {
                required: true,
                maxlength: 255
            },
            UnifiedSocialCreditldentifier: {
                required: false,
                maxlength: 18
            }
            
        },

        messages: {
            Email: {
                remote: "Email already in use"
            },
            ShipperName: {
                remote: "ShipperName already in use"
            }


        }


    });


    $('.f2 fieldset:first').fadeIn('slow');

    //$('.f2 input[type="text"], .f2 input[type="password"], .f2 textarea').on('focus', function () {
    //    $(this).removeClass('input-error');
    //});

    // next step
    $('.f2 .btn-next').on('click', function () {
        var parent_fieldset = $(this).parents('fieldset');
        var next_step = true;
        // navigation steps / progress steps
        var current_active_step = $(this).parents('.f2').find('.f2-step.active');
        var progress_line = $(this).parents('.f2').find('.f2-progress-line');

        // fields validation
        parent_fieldset.find('input[type="text"], input[type="password"],input[type="email"],select').each(function () {
            //console.log($(this).valid());
            if ($(this).valid()==false) {
                next_step = false;
            }
            else {
             
            }
        });
        // fields validation

        if (next_step) {
            parent_fieldset.fadeOut(400, function () {
                // change icons
                current_active_step.removeClass('active').addClass('activated').next().addClass('active');
                // progress bar
                bar_progress(progress_line, 'right');
                // show next step
                $(this).next().fadeIn();
                // scroll window to beginning of the form
                scroll_to_class($('.f2'), 20);
            });
        }

    });

    // previous step
    $('.f2 .btn-previous').on('click', function () {
        // navigation steps / progress steps
        var current_active_step = $(this).parents('.f2').find('.f2-step.active');
        var progress_line = $(this).parents('.f2').find('.f2-progress-line');

        $(this).parents('fieldset').fadeOut(400, function () {
            // change icons
            current_active_step.removeClass('active').prev().removeClass('activated').addClass('active');
            // progress bar
            bar_progress(progress_line, 'left');
            // show previous step
            $(this).prev().fadeIn();
            // scroll window to beginning of the form
            scroll_to_class($('.f2'), 20);
        });
    });

    // submit
    $('.f2').on('submit', function (e) {
        
        if ($f2.valid() == false) {
                e.preventDefault();
            }
        else {
            
            }


    });
    
    
});

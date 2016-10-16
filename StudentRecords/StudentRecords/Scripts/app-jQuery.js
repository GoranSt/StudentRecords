

$(document).ready(function () {

  
    // alert
    function SuccessAlertMessage() {
        //$("#add-student, #subjectbtn").click(function () {
        //$.post( $("#updateunit").attr("action"), 
        // $("#updateunit :input").serializeArray(),function(info){ 
        $(".result").html('<div class="alert alert-success"><button type="button" class="close">×</button>Successfully updated record!</div>');
        window.setTimeout(function () {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 5000);
        $('.alert .close').on("click", function (e) {
            $(this).parent().fadeTo(500, 0).slideUp(500);
        });
        //});
    }
     //ends here



    // back to top
    $('body').prepend('<a href="#" class="back-to-top">Back to Top</a>');

    var amountScrolled = 300;

    $(window).scroll(function () {
        if ($(window).scrollTop() > amountScrolled) {
            $('a.back-to-top').fadeIn('slow');
        } else {
            $('a.back-to-top').fadeOut('slow');
        }
    });

    $('a.back-to-top, a.simple-back-to-top').click(function () {
        $('html, body').animate({
            scrollTop: 0
        }, 700);
        return false;
    });

    // ends here






    // to prevent a form to be submitted (the page is refreshed)
    $("#subjectbtn").click(function (e) {
        e.preventDefault();    // This prevents form from being sumbitted
        
    });






    getStudents();
    getSubjects("", "", 3);



   
    
    $(document).on("click", ".deleteSubject", function () {
       
        var $sId = $(this).val();
       
            value = $(this).val();
        $.ajax({

            type: 'DELETE',
            url: '/api/Subjects/' + $sId,

            success: function (subjects) {
               

                var status = $("#sample_search");
               
                //alert(status.val());
                getSubjects(status.val(), status, 3);
                
            },
            error: function () {


                //alert('error getting students!');
            }

        });


    });



 // show student form / hide button Add student
    $(".btnn").click(function () {
        $(".form-student").show("slow", "swing");
       $('.btnn').hide("slow");
          
           
        
    });
    // hide form / show button Add student / clear field text if canceled
    $("#close").click(function () {

        $('.btnn').show("slow", "swing");
        $('#name').val("");
        $(".form-student").hide("slow");
    });
   


    //listing students  
    function getStudents() {
        
        $.ajax({

            type: 'GET',
            url: '/api/Students',

            success: function (students) {
                $('#myselect').empty();

                $.each(students, function (i, value) {
                    $('#myselect').append($('<option>').text(value.Name).attr('value', value.Id));

                    //$('#div1').append(value.Name).append("<br>");

                });
            },
            error: function () {


                //alert('error getting students!');
            }

        });

    };



    //POST adding new student 
    var $name = $('#name');
    $("#add-student").click(function () {

        var student = {

            name: $name.val()


        };

        $.ajax({

            type: 'POST',
            url: '/api/Students',
            data: student,
            // refreshing  the list of students after adding new student
            success: function (newStudent) {


                $name.val("");
                $('.btnn').show("slow");
                $('.form-student').hide("slow");
                


                getStudents();

                // bootstrap success message - bottom
                SuccessAlertMessage();
            },
            error: function () {

                //alert('error saving student!');

            }

        });



    });



    //GET  getting details for subject

    $("#subjectbtn").click(function () {

        var $studentId = $('#myselect').val();
        var $title = $('#inputTitle');
        var $credits = $('#inputCredits');
        var $description = $('#inputDescription');
        var $semester = $('#inputSemester');
        var $difficulty = $('#inputDifficulty');
        var $student;
        $.ajax({

            type: 'GET',
            url: '/api/Students/' + $studentId,
            data: subject,
            success: function (newStudent) {
              
              
                $student = newStudent;
            }

        });

        var subject = {

            StudentId: $studentId,

            Title: $title.val(),
            Credits: $credits.val(),
            Description: $description.val(),
            Difficulty: $difficulty.val(),
            Semestar: $semester.val(),

            Student: $student
        };


        $.ajax({

            type: 'POST',
            url: '/api/Subjects',
            data: subject,
            success: function () {

               

                //self.subjects.push(newSubject);



                getSubjects("", "", 3);


                // bootstrap success message - bottom
                SuccessAlertMessage();


              // for deleting text from the textfields after submiting a subject
                   $title.val(""),
                    $credits.val(""),
                     $description.val(""),
                     $semester.val(""),
                    $difficulty.val("")


            },
            error: function () {

               

            },

        });


    });


   
        $(document).on("click", ".details", function () {
          

            
            var $details;
            var $sId = $(this).val();

         
            $.ajax({

                type: 'GET',
                url: 'api/Subjects/' + $sId,
             
                success: function (data) {
                   
                    $details = data;

                 
                    $('#StudentName').text($details.StudentName);
                    $('#Credits').text($details.Credits);
                    $('#Title').text($details.Title);
                  
                    $('#Semester').text($details.Semestar);
                    $('#Difficulty').text($details.Difficulty);
                    $('#Description').text($details.Description);
                   
                }

            });


        });
    
        
        var searchRequest = null;

        $(function () {
            var minlength = 3;
            
            $("#sample_search").keyup(function () {

                var that = this,
            value = $(this).val();

                getSubjects(value, that, minlength);



            });
        });
 
   
        function getSubjects(value, that, minlength) {
            $('#SubjectList').empty("slow");

            if(value.length !== 0){


            if (value.length >= minlength) {
                if (searchRequest != null)
                    searchRequest.abort();

                searchRequest = $.ajax({

                    type: "GET",
                    url: "api/Subjects/search/" + value,
                    //data: {
                    //    'search_keyword': value
                    //},
                    //dataType: "text",
                    success: function (subjects) {
                        
                      
                        // if the value is the same
                        if (value == $(that).val()) {
                           

                            //Receiving the result of search here
                            $('#printSubjects').text(subjects);

                            
                          
                            $.each(subjects, function (i, value) {
                              
                                $('#SubjectList').append('<p class="post"><li class="post"><li><strong>' + value.StudentName +
                                '</strong><br>' + value.Title + '</li>' + '<li><button name="btnDetails" class="btn btn-info details" value=' + value.Id +
                                '>' + 'Details</button>&nbsp;<button class="deleteSubject btn btn-danger" value=' + value.Id +
                                '>Delete</button></li></li></p><hr>');

                            });
                           
                        }
                    }
                });
            }


            }
            else{

           
            $.ajax({

                type: 'GET',
                url: '/api/Subjects',

                success: function (subjects) {
                    $('#printSubjects').text(subjects);


                    $.each(subjects, function (i, value) {
                       


                        $('#SubjectList').append('<p class="post"><li class="post"><li><strong>' + value.StudentName +
                        '</strong><br>' + value.Title + '</li>' + '<li><button name="btnDetails" class="btn btn-info details" value=' +
                        value.Id + '>' + '<span class="glyphicon glyphicon-info-sign"></span> Details</button>&nbsp;<button class="deleteSubject btn btn-danger" value=' +
                        value.Id + '>Delete <span class="glyphicon glyphicon-remove"></span></button></li></li></p><hr>');

                    });
                },
                error: function () {
                    //alert('error printing subjects');
                }
            });

            }
        };


});


// previous solution using Knockout js

//self.addSubject = function (formElement) {
//    var subject = {
//        StudentId: self.newSubject.Student().Id,
//        Title: self.newSubject.Title(),
//        Credits: self.newSubject.Credits()
//    };

//    ajaxHelper(subjectsUri, 'POST', subject).done(function (item) {
//        self.subjects.push(item);
//    });
//}

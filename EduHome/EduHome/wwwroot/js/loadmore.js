let skipCount = 3;
$(document).on("click", "#LoadMoreBtn", function () {
    $.ajax({
        url: "/Courses/LoadMore/",
        type:"GET",
        data: {
            "skip": skipCount
        },

        success: function (response)
        {
            $("#myCourses").append(response)
            skipCount += 3;
            if ($("#coursesCount").val() <= skipCount) {
                $("#LoadMoreBtn").remove()
            }
        }
    });
});
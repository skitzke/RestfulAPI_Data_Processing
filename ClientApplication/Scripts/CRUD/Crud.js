function testInsert()
{
    var hdiRank = $("#hdiRank").val();
    var Country = $("#country").val();
    var _2010 = $("#y2010").val();
    var _2011 = $("#y2011").val();
    var _2012 = $("#y2012").val();
    var _2013 = $("#y2013").val();
    var _2014 = $("#y2014").val();

    $.ajax({
        type: "POST",
        url: "https://localhost:44313/api/HDI/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { hdiRank: hdiRank, Country : Country, _2010 :  _2010, _2011: _2011, _2012: _2012, _2013: _2013, _2014: _2014},
        success: function (data) {
            alert("success");
        },
        failure: function (qXHR, textStatus) {
            alert("Request failed: " + textStatus);
        }
    })
}
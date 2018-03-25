// Write your JavaScript code.

var x_enitableExtends = function () {
    return {
        getGenderName: function (gender) {
            var result = '保密';
            if (gender == '1') {
                result = '男';
            } else if (gender == '2') {
                result = '女'
            } else {
                result = '保密';
            }
            return result;
        },
        getDepartmentsName: function (key, partList) {
            var jsonData = JSON.stringify(partList);
            var result = '';
            for (var i = 0; i < jsonData.length; i++) {
                if (jsonData[i].Id == key) {
                    result = jsonData[i].Name;
                }
            }
            return result;
        }
    };
}
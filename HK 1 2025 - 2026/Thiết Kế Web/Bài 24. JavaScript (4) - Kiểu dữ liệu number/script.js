// Lấy các phần tử DOM cần thiết

const display = document.getElementById('display');

const keys = document.querySelector('.calculator-keys');



// Đối tượng lưu trữ trạng thái của máy tính

const calculator = {

    displayValue: '0',

    firstOperand: null,

    waitingForSecondOperand: false,

    operator: null,

};



// Hàm cập nhật màn hình hiển thị

function updateDisplay() {

    // Hiển thị giá trị hiện tại. Cắt bớt nếu quá dài.

    let displayString = String(calculator.displayValue);

   

    // Xử lý các giá trị đặc biệt (Infinity, -Infinity, NaN)

    if (displayString.includes('Infinity')) {

        display.textContent = 'Lỗi: Vô cực';

    } else if (displayString === 'NaN') {

        display.textContent = 'Lỗi: Không phải số';

    } else {

        display.textContent = displayString.length > 18

            ? parseFloat(displayString).toPrecision(15)

            : displayString;

    }

}



// Hàm xử lý nhập số

function inputDigit(digit) {

    const { displayValue, waitingForSecondOperand } = calculator;



    if (waitingForSecondOperand === true) {

        calculator.displayValue = digit;

        calculator.waitingForSecondOperand = false;

    } else {

        // Nếu displayValue là '0', thay thế bằng digit mới, ngược lại nối thêm

        calculator.displayValue = displayValue === '0' ? digit : displayValue + digit;

    }



    updateDisplay();

}



// Hàm xử lý dấu thập phân

function inputDecimal(dot) {

    // Không cho phép nhập dấu thập phân nếu đang chờ toán hạng thứ hai

    if (calculator.waitingForSecondOperand === true) {

        calculator.displayValue = '0.';

        calculator.waitingForSecondOperand = false;

        updateDisplay();

        return;

    }



    // Chỉ cho phép thêm dấu thập phân nếu chưa có

    if (!calculator.displayValue.includes(dot)) {

        calculator.displayValue += dot;

    }



    updateDisplay();

}



// Hàm xử lý toán tử

function handleOperator(nextOperator) {

    const { firstOperand, displayValue, operator } = calculator;

    // Chuyển giá trị hiển thị thành số thực

    const inputValue = parseFloat(displayValue);
    // Quy đổi action -> ký hiệu thật
    const operatorMap = {
        add: '+',
        subtract: '-',
        multiply: '*',
        divide: '/',
        exponentiation: '^',
        modulo: '%'
    };

    // Nếu nextOperator là chữ (add/subtract/...) thì đổi sang ký hiệu
    const realOperator = operatorMap[nextOperator] || nextOperator;



    // Kiểm tra Number.isFinite() như trong tài liệu

    if (!Number.isFinite(inputValue) && inputValue !== 0) {

         // Không làm gì nếu giá trị hiện tại là NaN, Infinity, -Infinity

        calculator.displayValue = 'Lỗi phép toán';

        updateDisplay();

        return;

    }





    if (firstOperand === null) {

        // Đây là toán hạng đầu tiên

        calculator.firstOperand = inputValue;

    } else if (operator) {

        // Có toán tử và đã có toán hạng thứ nhất -> Thực hiện tính toán

        const result = performCalculation[operator](firstOperand, inputValue);



        // Cập nhật kết quả, làm tròn nếu cần (để tránh lỗi số học dấu phẩy động)

        calculator.displayValue = String(result);

        calculator.firstOperand = result;

    }



    // Cập nhật trạng thái cho phép toán tiếp theo

    calculator.waitingForSecondOperand = true;

    calculator.operator = realOperator;

   

    updateDisplay();

}



// Đối tượng chứa logic tính toán cho từng toán tử

const performCalculation = {

    '/': (firstOperand, secondOperand) => firstOperand / secondOperand,

    '*': (firstOperand, secondOperand) => firstOperand * secondOperand,

    '+': (firstOperand, secondOperand) => firstOperand + secondOperand,

    '-': (firstOperand, secondOperand) => firstOperand - secondOperand,

    // Lũy thừa (Exponentiation): sử dụng toán tử **

    '^': (firstOperand, secondOperand) => firstOperand ** secondOperand,

    // Phép chia dư (Modulo)

    '%': (firstOperand, secondOperand) => firstOperand % secondOperand,

};



// Hàm thiết lập lại máy tính

function resetCalculator() {

    calculator.displayValue = '0';

    calculator.firstOperand = null;

    calculator.waitingForSecondOperand = false;

    calculator.operator = null;

    updateDisplay();

}



// Lắng nghe sự kiện click trên các nút

keys.addEventListener('click', (event) => {

    const { target } = event;

    const action = target.dataset.action;

    const value = target.dataset.value;



    // Đảm bảo chỉ xử lý các nút (button)

    if (!target.matches('button')) {

        return;

    }



    // Xử lý nút số

    if (value !== undefined) {

        inputDigit(value);

        return;

    }



    // Xử lý các hành động

    if (action === 'decimal') {

        inputDecimal('.');

        return;

    }



    if (action === 'clear') {

        resetCalculator();

        return;

    }



    // Nếu là phép toán hoặc dấu bằng

    if (action) {
        // Bảng quy đổi hành động -> ký hiệu toán tử thật
        const operatorMap = {
            add: '+',
            subtract: '-',
            multiply: '*',
            divide: '/',
            exponentiation: '^',
            modulo: '%'
        };
    
        if (action === 'calculate') {
            // Nếu người dùng nhấn "="
            if (calculator.operator) {
                const result = performCalculation[calculator.operator](
                    calculator.firstOperand,
                    parseFloat(calculator.displayValue)
                );
    
                calculator.displayValue = String(result);
                calculator.firstOperand = result;
                calculator.operator = null;
                calculator.waitingForSecondOperand = true;
                updateDisplay();
            }
        } else {
            // Nếu là các toán tử khác (+, -, x, /, ^, %)
            const realOperator = operatorMap[action] || action;
            handleOperator(realOperator);
        }
    
        return;

    }

});



// Khởi tạo hiển thị

updateDisplay();
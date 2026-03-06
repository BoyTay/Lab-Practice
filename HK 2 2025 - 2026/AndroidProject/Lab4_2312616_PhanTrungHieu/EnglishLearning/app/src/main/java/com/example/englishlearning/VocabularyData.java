package com.example.englishlearning;

import java.util.HashMap;
import java.util.Map;

public class VocabularyData {

    // Từ vựng theo chủ đề (topic index -> danh sách từ)
    private static final Map<Integer, String[]> VOCABULARY_MAP = new HashMap<>();

    static {
        // 0: Essentials
        VOCABULARY_MAP.put(0, new String[]{
                "Hello - Xin chào",
                "Thank you - Cảm ơn",
                "Please - Làm ơn",
                "Sorry - Xin lỗi",
                "Yes - Có",
                "No - Không",
                "Help - Giúp đỡ",
                "Good morning - Chào buổi sáng"
        });

        // 1: While Traveling
        VOCABULARY_MAP.put(1, new String[]{
                "Airport - Sân bay",
                "Passport - Hộ chiếu",
                "Ticket - Vé",
                "Luggage - Hành lý",
                "Flight - Chuyến bay",
                "Boarding - Lên máy bay",
                "Customs - Hải quan",
                "Departure - Khởi hành"
        });

        // 2: Help / Medical
        VOCABULARY_MAP.put(2, new String[]{
                "Doctor - Bác sĩ",
                "Hospital - Bệnh viện",
                "Medicine - Thuốc",
                "Pain - Đau",
                "Emergency - Khẩn cấp",
                "Ambulance - Xe cấp cứu",
                "Allergy - Dị ứng",
                "Prescription - Đơn thuốc"
        });

        // 3: At the hotel
        VOCABULARY_MAP.put(3, new String[]{
                "Room - Phòng",
                "Check-in - Nhận phòng",
                "Check-out - Trả phòng",
                "Key - Chìa khóa",
                "Reservation - Đặt phòng",
                "Breakfast - Bữa sáng",
                "Lobby - Sảnh khách sạn",
                "Wi-Fi - Mạng không dây"
        });

        // 4: At the Restaurant
        VOCABULARY_MAP.put(4, new String[]{
                "Menu - Thực đơn",
                "Order - Đặt món",
                "Waiter - Người phục vụ",
                "Bill - Hóa đơn",
                "Appetizer - Món khai vị",
                "Main course - Món chính",
                "Dessert - Món tráng miệng",
                "Tip - Tiền thưởng"
        });

        // 5: At the Bar
        VOCABULARY_MAP.put(5, new String[]{
                "Cocktail - Rượu cocktail",
                "Beer - Bia",
                "Wine - Rượu vang",
                "Bartender - Người pha chế",
                "Glass - Ly",
                "Ice - Đá",
                "Cheers - Chúc mừng",
                "Non-alcoholic - Không cồn"
        });

        // 6: At the Store
        VOCABULARY_MAP.put(6, new String[]{
                "Price - Giá",
                "Discount - Giảm giá",
                "Receipt - Hóa đơn",
                "Cash - Tiền mặt",
                "Credit card - Thẻ tín dụng",
                "Shopping cart - Xe đẩy hàng",
                "Cashier - Thu ngân",
                "Sale - Khuyến mãi"
        });

        // 7: Work
        VOCABULARY_MAP.put(7, new String[]{
                "Meeting - Cuộc họp",
                "Deadline - Hạn chót",
                "Project - Dự án",
                "Colleague - Đồng nghiệp",
                "Manager - Quản lý",
                "Report - Báo cáo",
                "Office - Văn phòng",
                "Salary - Lương"
        });

        // 8: Time
        VOCABULARY_MAP.put(8, new String[]{
                "Morning - Buổi sáng",
                "Afternoon - Buổi chiều",
                "Evening - Buổi tối",
                "Yesterday - Hôm qua",
                "Today - Hôm nay",
                "Tomorrow - Ngày mai",
                "Week - Tuần",
                "Month - Tháng"
        });

        // 9: Education
        VOCABULARY_MAP.put(9, new String[]{
                "School - Trường học",
                "Teacher - Giáo viên",
                "Student - Học sinh",
                "Homework - Bài tập về nhà",
                "Exam - Kỳ thi",
                "Grade - Điểm số",
                "Classroom - Lớp học",
                "Library - Thư viện"
        });

        // 10: Entertainment
        VOCABULARY_MAP.put(10, new String[]{
                "Movie - Phim",
                "Actor - Diễn viên",
                "Director - Đạo diễn",
                "Ticket - Vé",
                "Popcorn - Bỏng ngô",
                "Cinema - Rạp chiếu phim",
                "Subtitle - Phụ đề",
                "Scene - Cảnh phim"
        });
    }

    public static String[] getVocabulary(int topicIndex) {
        return VOCABULARY_MAP.getOrDefault(topicIndex, new String[]{});
    }
}


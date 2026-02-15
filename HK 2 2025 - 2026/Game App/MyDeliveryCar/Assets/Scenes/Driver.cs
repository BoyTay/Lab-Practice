using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.2f;// SerializeField Câu lệnh này cho phép bạn nhìn thấy và chỉnh sửa giá trị của biến ngay trên bảng Inspector của Unity, ngay cả khi biến đó là private. Bạn không cần quay lại code để đổi tốc độ.
    [SerializeField] float steerSpeed = 0.2f;

    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()//Chạy duy nhất một lần khi bạn nhấn nút Play
    {
        
    }

    // Update is called once per frame
    void Update()//Chạy liên tục trong mọi khung hình (khoảng 60-120 lần mỗi giây tùy máy). Đây là nơi xử lý các chuyển động.
    {
        float changeStreer = Input.GetAxis("Horizontal")*steerSpeed * Time.deltaTime;//Lấy giá trị từ bàn phím (trái/phải) và nhân với tốc độ xoay
        float changeMove = Input.GetAxis("Vertical")*moveSpeed * Time.deltaTime;//Lấy giá trị từ bàn phím (lên/xuống) và nhân với tốc độ di chuyển
        transform.Rotate(0,0,-changeStreer);//Xoay đối tượng quanh trục Z dựa trên giá trị từ bàn phím
        transform.Translate(0,changeMove,0);//Dịch chuyển đối tượng theo trục Y dựa trên giá trị từ bàn phím
        


        //transform.Translate(0,moveSpeed,0);//Lệnh này dịch chuyển đối tượng theo trục Y
        //transform.Rotate(0,0,steerSpeed);//Lệnh này xoay đối tượng quanh trục Z
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = normalSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}

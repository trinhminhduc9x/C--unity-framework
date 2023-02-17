using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    public float VanToc;
    private float TocDo =0; // Toc Do cua Mario
    private bool DuoiDat=true; // Kiem tra mario cos owr duwois ddat hay ko
    private bool ChuyenHuong=false; // Kiem tra mario cos chuyen huong hay ko
    private bool QuayPhai = true;

    public float NhayCao;

    private Rigidbody2D r2d;
    private Animator HoatHoa;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        HoatHoa = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HoatHoa.SetFloat("TocDo", TocDo);
        HoatHoa.SetBool("DuoiDat", DuoiDat);
        HoatHoa.SetBool("ChuyenHuong", ChuyenHuong);
        NhayLen();
    }

    private void FixedUpdate()
    {
        DiChuyen();
    }


    void DiChuyen()
    {
        // Chi nhan khi bam A-1 0 1
        float PhimNhanPhaiTrai = Input.GetAxisRaw("Horizontal");
        r2d.velocity = new Vector2(VanToc * PhimNhanPhaiTrai, r2d.velocity.y);
        TocDo = Mathf.Abs(VanToc * PhimNhanPhaiTrai);
        if (PhimNhanPhaiTrai > 0 && !QuayPhai) HuongmatMario();
        if (PhimNhanPhaiTrai < 0 && QuayPhai) HuongmatMario();


    }
    void HuongmatMario()
    {
        if (QuayPhai = !QuayPhai);
        Vector2 HuongQuay = transform.localScale;
        HuongQuay.x *= -1;
        transform.localScale = HuongQuay;
    }

    void NhayLen()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DuoiDat == true)
        {
            r2d.AddForce((Vector2.up) * NhayCao);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Gold")
        {
            Destroy(collision.gameObject);
        }
    }
}

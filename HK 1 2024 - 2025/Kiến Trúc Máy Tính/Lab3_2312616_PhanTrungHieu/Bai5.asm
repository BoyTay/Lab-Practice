.model small
.stack 100h
.data
    char db "Nhap mot ky tu: $"
    str  db 10,13,"Nam ky tu ke tiep: $"     ; hien thi 5 ky tu dung truoc  
    newl db 10,13,"$"
.code
    mov ax, @data
    mov ds, ax
    
    mov dx, offset char
    mov ah, 9
    int 21h
    
    mov ah,1  ; nhap 1 ky tu 
    int 21h
    mov bl, al
    sub bl, 5
    
    mov dx, offset str
    mov ah, 9
    int 21h  
    
    mov cx, 5 ; khoi tao so lan lap (loop)
    
    Lap_In:
        mov dl, bl   
        mov ah, 2  ; xuat 1 ky tu
        int 21h
        
        inc bl
        
        call Xuong_Dong
        loop Lap_In
        
        ; Thoat chuong trinh
        mov ah, 4ch
        int 21h 
        
    Xuong_Dong:
        mov dx, offset newl
        mov ah, 9
        int 21h 
        ret
end

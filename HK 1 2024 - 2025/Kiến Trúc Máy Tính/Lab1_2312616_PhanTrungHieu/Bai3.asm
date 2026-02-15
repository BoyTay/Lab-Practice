.model small 
.stack 100h
.data
    a db 'Nhap 1 ki tu: $1'
    b db 13,10,'Ki tu dung truoc: $'
    c db 13,10,'Ki tu dung sau: $'
    d db ?
.code     
    mov ax, @data
    mov ds,ax
    
    mov ah,9
    lea dx, a
    int 21h 
     
    mov ah,1
    int 21h
    
    mov d, al
    dec d
    
    mov ah,9
    lea dx, b  
    int 21h
    
    mov ah,2 
    mov dl, d
    int 21h
    
    add d, 2
    
    mov ah,9
    lea dx, c 
    int 21h
    
    mov ah,2 
    mov dl, d
    int 21h
    
    mov ah, 4ch
    int 21h
    
    
end


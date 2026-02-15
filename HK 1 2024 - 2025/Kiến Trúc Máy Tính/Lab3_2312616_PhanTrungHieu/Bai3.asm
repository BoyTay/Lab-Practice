.model small
.stack 100h
.data
    str DB "Bang Chu Cai In Hoa ASCII: ",10,13,"$"
    
.code  
    mov AX, @data
    mov DS, AX
    
    mov DX, offset str
    mov AH, 9
    int 21h
    
    mov CX, 26
    mov AL, 'A'
    
    Lap_In:
        mov DL, AL
        mov AH, 2
        int 21h
        
        inc AL 
        loop Lap_In
        
        ; Thoat Chuong Trinh
        mov AH, 4ch
        int 21h
        
  
end
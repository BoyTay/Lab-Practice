.model small
.stack 100h
.data
    char DB "Nhap mot ky tu: $"
    str  DB 10,13,"Nam ky tu ke tiep: $"
    newl DB 10,13,"$"
.code
     mov AX, @data
     mov DS, AX
     
     mov DX, offset char
     mov AH, 9
     int 21h
     
     mov AH, 1
     int 21h 
     mov BL, AL
     add BL, 1
     mov DX, offset str
     mov AH, 9
     int 21h

     mov CX, 5
     
     Lap_In:
        mov DL, BL
        mov AH, 2
        int 21h
        
        inc bl
        
        mov DX, offset newl
        mov AH, 9
        int 21h
        
        loop Lap_In
        
        mov AH, 4ch
        int 21h
end

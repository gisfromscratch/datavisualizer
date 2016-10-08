#-------------------------------------------------
#
# Project created by QtCreator 2016-10-08T14:29:27
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = QtTableApp
TEMPLATE = app


SOURCES += main.cpp\
        MainWindow.cpp \
    SimpleTableModel.cpp

HEADERS  += MainWindow.h \
    SimpleTableModel.h

FORMS    += MainWindow.ui

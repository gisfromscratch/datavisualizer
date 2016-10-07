
// MfcTableAppView.cpp : implementation of the CMfcTableAppView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "MfcTableApp.h"
#endif

#include "MfcTableAppDoc.h"
#include "MfcTableAppView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMfcTableAppView

IMPLEMENT_DYNCREATE(CMfcTableAppView, CListView)

BEGIN_MESSAGE_MAP(CMfcTableAppView, CListView)
END_MESSAGE_MAP()

// CMfcTableAppView construction/destruction

CMfcTableAppView::CMfcTableAppView()
{
	// TODO: add construction code here

}

CMfcTableAppView::~CMfcTableAppView()
{
}

BOOL CMfcTableAppView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CListView::PreCreateWindow(cs);
}

void CMfcTableAppView::OnInitialUpdate()
{
	// Set the style of the list view
	CListCtrl &listCtrl = GetListCtrl();
	DWORD listStyle = GetWindowLong(listCtrl.m_hWnd, GWL_STYLE);
	listStyle |= LVS_REPORT;
	SetWindowLong(listCtrl.m_hWnd, GWL_STYLE, listStyle);

	CListView::OnInitialUpdate();


	// TODO: You may populate your ListView with items by directly accessing
	//  its list control through a call to GetListCtrl().
}


// CMfcTableAppView diagnostics

#ifdef _DEBUG
void CMfcTableAppView::AssertValid() const
{
	CListView::AssertValid();
}

void CMfcTableAppView::Dump(CDumpContext& dc) const
{
	CListView::Dump(dc);
}

CMfcTableAppDoc* CMfcTableAppView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMfcTableAppDoc)));
	return (CMfcTableAppDoc*)m_pDocument;
}
#endif //_DEBUG


// CMfcTableAppView message handlers

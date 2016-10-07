
// MfcTableAppDoc.cpp : implementation of the CMfcTableAppDoc class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "MfcTableApp.h"
#endif

#include "MfcTableAppDoc.h"
#include "MfcTableAppView.h"

#include <propkey.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CMfcTableAppDoc

IMPLEMENT_DYNCREATE(CMfcTableAppDoc, CDocument)

BEGIN_MESSAGE_MAP(CMfcTableAppDoc, CDocument)
END_MESSAGE_MAP()


// CMfcTableAppDoc construction/destruction

CMfcTableAppDoc::CMfcTableAppDoc()
{
	// TODO: add one-time construction code here

}

CMfcTableAppDoc::~CMfcTableAppDoc()
{
}

BOOL CMfcTableAppDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}

BOOL CMfcTableAppDoc::OnOpenDocument(LPCTSTR lpszPathName)
{
	if (!CDocument::OnOpenDocument(lpszPathName))
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	CStdioFile inputFile;
	if (!inputFile.Open(lpszPathName, CFile::modeRead))
	{
		return FALSE;
	}

	// Try to find the active view
	CFrameWnd *window = (CFrameWnd*)(AfxGetApp()->m_pMainWnd);
	CView *activeView = window->GetActiveView();

	if (!activeView)
	{
		return FALSE;
	}

	// Fail if view is of wrong kind
	// (this could occur with splitter windows, or additional
	// views on a single document
	if (!activeView->IsKindOf(RUNTIME_CLASS(CMfcTableAppView)))
	{
		return FALSE;
	}

	CMfcTableAppView *tableView = (CMfcTableAppView*)activeView;
	CListCtrl &tableCtrl = tableView->GetListCtrl();
	if (!tableCtrl.DeleteAllItems())
	{
		return FALSE;
	}
	int columnCount = 0;
	int recordCount = 0;

	// Deactivate paint
	tableCtrl.SetRedraw(FALSE);

	// Virtual list view
	// https://msdn.microsoft.com/en-us/library/ye4z8x58.aspx

	// Read the file
	CString line, token;
	LVITEMW item;
	while (inputFile.ReadString(line))
	{
		int tokenIndex = 0;
		if (0 == columnCount)
		{
			for (CString token = line.Tokenize(_T(","), tokenIndex); !token.IsEmpty(); token = line.Tokenize(_T(","), tokenIndex), columnCount++)
			{
				tableCtrl.InsertColumn(columnCount, token);
			}

			// Set the column size to auto after all columns were added
			for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
			{
				tableCtrl.SetColumnWidth(columnIndex, LVSCW_AUTOSIZE_USEHEADER);
			}
		}
		else
		{
			item.mask = LVIF_TEXT;
			item.iItem = recordCount++;
			int columnIndex = 0;
			for (CString token = line.Tokenize(_T(","), tokenIndex); !token.IsEmpty(); token = line.Tokenize(_T(","), tokenIndex), columnIndex++)
			{
				item.iSubItem = columnIndex;
				item.pszText = (LPTSTR)(LPCTSTR)token;

				switch (columnIndex)
				{
				case 0:
					// Insert the record with one value
					tableCtrl.InsertItem(&item);
					break;

				default:
					// Update the other values
					tableCtrl.SetItem(&item);
					break;
				}
			}
		}
	}

	// Activate paint
	tableCtrl.SetRedraw(TRUE);

	return TRUE;
}




// CMfcTableAppDoc serialization

void CMfcTableAppDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

#ifdef SHARED_HANDLERS

// Support for thumbnails
void CMfcTableAppDoc::OnDrawThumbnail(CDC& dc, LPRECT lprcBounds)
{
	// Modify this code to draw the document's data
	dc.FillSolidRect(lprcBounds, RGB(255, 255, 255));

	CString strText = _T("TODO: implement thumbnail drawing here");
	LOGFONT lf;

	CFont* pDefaultGUIFont = CFont::FromHandle((HFONT) GetStockObject(DEFAULT_GUI_FONT));
	pDefaultGUIFont->GetLogFont(&lf);
	lf.lfHeight = 36;

	CFont fontDraw;
	fontDraw.CreateFontIndirect(&lf);

	CFont* pOldFont = dc.SelectObject(&fontDraw);
	dc.DrawText(strText, lprcBounds, DT_CENTER | DT_WORDBREAK);
	dc.SelectObject(pOldFont);
}

// Support for Search Handlers
void CMfcTableAppDoc::InitializeSearchContent()
{
	CString strSearchContent;
	// Set search contents from document's data. 
	// The content parts should be separated by ";"

	// For example:  strSearchContent = _T("point;rectangle;circle;ole object;");
	SetSearchContent(strSearchContent);
}

void CMfcTableAppDoc::SetSearchContent(const CString& value)
{
	if (value.IsEmpty())
	{
		RemoveChunk(PKEY_Search_Contents.fmtid, PKEY_Search_Contents.pid);
	}
	else
	{
		CMFCFilterChunkValueImpl *pChunk = NULL;
		ATLTRY(pChunk = new CMFCFilterChunkValueImpl);
		if (pChunk != NULL)
		{
			pChunk->SetTextValue(PKEY_Search_Contents, value, CHUNK_TEXT);
			SetChunkValue(pChunk);
		}
	}
}

#endif // SHARED_HANDLERS

// CMfcTableAppDoc diagnostics

#ifdef _DEBUG
void CMfcTableAppDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CMfcTableAppDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CMfcTableAppDoc commands
